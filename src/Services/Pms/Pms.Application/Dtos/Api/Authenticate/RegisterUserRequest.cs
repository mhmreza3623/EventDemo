namespace Pms.Application.Dtos.Api.Authenticate;

public class RegisterUserRequest
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public bool IsActive { get; set; }
}