namespace Pms.Domain.Interfaces;

public interface IPaymentDomainService
{
    Task<string> GenerateToken();
    Task<bool> ValidateToken(string token);
}