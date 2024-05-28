using System.Security.Claims;
using Pms.Domain.Entities;

namespace Pms.Domain.Interfaces
{
    public interface IIdentityService
    {
        ClaimsPrincipal GetPrincipal(string token);
        Task<ApplicationUser> GenerateUser(string username, string password, bool isActive, Client client);
        Task<ApplicationUser> GetUser(string commandUserName);
        string GenerateToken(string username, string clientUxId, int expireMinutes = 20);
    }
}
