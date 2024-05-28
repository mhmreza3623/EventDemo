using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Identity.APIs.Models;

namespace Identity.APIs.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfigurationManager _configurationManager;

        public AuthenticationController(IConfigurationManager configurationManager)
        {
            _configurationManager = configurationManager;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] Login user)
        {
            if (user is null)
            {
                return BadRequest("Invalid user request!!!");
            }
            if (user.UserName == "Jaydeep" && user.Password == "Pass@777")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configurationManager.GetSection("JWT:Secret").Value));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(issuer: _configurationManager.GetSection("JWT:ValidIssuer").Value, audience: _configurationManager.GetSection("JWT:ValidAudience").Value, claims: new List<Claim>(), expires: DateTime.Now.AddMinutes(6), signingCredentials: signinCredentials);
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

                return Ok(new
                {
                    Token = tokenString
                });
            }
            return Unauthorized();
        }
    }
}
