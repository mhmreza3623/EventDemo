﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Pms.Application.Queries;
using Pms.Domain.Entities;
using Pms.Domain.Interfaces;
using SharedKernel.Identities;

namespace Pms.Infrastructure.Services.DomainServices
{
    public class IdentityService : IIdentityService
    {
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOptions<JwtModel> _jwtConfig;
        private readonly IUserRepository _userRepository;

        public IdentityService(IUserStore<ApplicationUser> userStore, UserManager<ApplicationUser> userManager, IOptions<JwtModel> jwtConfig, IUserRepository userRepository)
        {
            _userStore = userStore;
            _userManager = userManager;
            _jwtConfig = jwtConfig;
            _userRepository = userRepository;
        }

        public ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                    return null;

                var symmetricKey = Encoding.UTF8.GetBytes(_jwtConfig.Value.Secret);

                var validationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
                };

                var principal = tokenHandler.ValidateToken(token, validationParameters, out _);

                return principal;
            }

            catch (Exception)
            {
                return null;
            }
        }

        public Task<ApplicationUser> GetUserByUxId(Guid userUxId)
        {
            return  _userRepository
                .GetUsers(q => q.UxId == userUxId)
                .Include(q => q.Client)
                .SingleOrDefaultAsync();
        }

        public string GenerateClientUserToken(string username, string clientUxId, int expireMinutes = 2)
        {
            var symmetricKey = Encoding.UTF8.GetBytes(_jwtConfig.Value.Secret);
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(JwtRegisteredClaimNames.Aud, _jwtConfig.Value.Audience),
                    new Claim("CUxID", clientUxId),
                }),
                Expires = DateTime.Now.AddMinutes(Convert.ToInt32(expireMinutes)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return token;
        }

        public string GenerateToken(string username, int expireMinutes = 2)
        {
            var symmetricKey = Encoding.UTF8.GetBytes(_jwtConfig.Value.Secret);
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(JwtRegisteredClaimNames.Aud, _jwtConfig.Value.Audience),
                    new Claim("CUxID", string.Empty),
                }),
                Expires = DateTime.Now.AddMinutes(Convert.ToInt32(expireMinutes)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return token;
        }

        public async Task<bool> CheckPassword(string username, string password)
        {
            var user= await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                return await _userManager.CheckPasswordAsync(user, password);
            }

            return false;
        }

        public async Task<ApplicationUser?> GenerateClientUser(string username, string password, bool isActive, Client client)
        {
            var user = ApplicationUser.CreateClientUser(username, password, isActive, client);

            await _userStore.SetUserNameAsync(user, username, CancellationToken.None);

            var result = await _userManager.CreateAsync(user, password);

            return result.Succeeded ? user : null;
        }

        public async Task<ApplicationUser?> GenerateUser(string username, string password, bool isActive)
        {
            var user = ApplicationUser.Create(username, password, isActive);

            await _userStore.SetUserNameAsync(user, username, CancellationToken.None);

            var result = await _userManager.CreateAsync(user, password);

            return result.Succeeded ? user : null;
        }

        public  Task<ApplicationUser> GetUser(string userName)
        {
            return _userRepository
                .GetUsers(q => q.UserName == userName)
                .Include(q => q.Client)
                .SingleOrDefaultAsync();
        }
    }
}
