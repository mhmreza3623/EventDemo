using Pms.Domain.Interfaces;

namespace Pms.Infrastructure.Services.DomainServices
{
    public class PaymentDomainService : IPaymentDomainService
    {
        public async Task<string> GenerateToken()
        {
            return GenerateUniqueToken();
        }

        public async Task<bool> ValidateToken(string token)
        {
            var tokenExpireDate = token.Split("_");
            if (tokenExpireDate != null && tokenExpireDate.Count() != 3)
            {
                return false;
            }

            var expireDate = UnixTimeStampToDateTime(double.Parse(tokenExpireDate[0]));
            return !((DateTime.Now - expireDate).TotalMinutes > 2);
        }

        static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }

        static string GenerateUniqueToken()
        {
            var expirationTime = DateTimeOffset.Now
                .AddMinutes(2)
                .ToUnixTimeSeconds(); // Expiration time set to 1 hour from now

            var requestId = Guid.NewGuid().ToString("N"); // Generate a unique request ID
            var randomPattern = GenerateRandomPattern(10); // Generate a random pattern
            var uniqueToken = $"{expirationTime}_{requestId}_{randomPattern}";

            return uniqueToken;
        }

        static string GenerateRandomPattern(int length)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }


    }
}
