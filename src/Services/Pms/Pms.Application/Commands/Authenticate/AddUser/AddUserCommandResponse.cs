using Pms.Domain.Common.Enums;

namespace Pms.Application.Commands.Authenticate.AddUser;

public class AddUserCommandResponse : BaseCommandResponse
{
    public AddUserCommandResponse(bool succeed, ErrorCodes? errorCode = null) : base(succeed, errorCode)
    {
    }

    public string? UserName { get; set; }
    public Guid UxId { get; set; }
    public string AccessToken { get; set; }
}