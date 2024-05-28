using System.Security.Claims;
using Pms.Domain.Entities;

namespace Pms.Domain.Interfaces
{
    public interface IIdentityService
    {
        ClaimsPrincipal GetPrincipal(string token);
        Task<ApplicationUser?> GenerateClientUser(string username, string password, bool isActive, Client client);
        Task<ApplicationUser?> GenerateUser(string username, string password, bool isActive);
        Task<ApplicationUser> GetUser(string commandUserName);
        string GenerateClientUserToken(string username, string clientUxId, int expireMinutes = 20);
        string GenerateToken(string username, int expireMinutes = 20);
        Task<bool> CheckPassword(string username, string password);
    }
}
