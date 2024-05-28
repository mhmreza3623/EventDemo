using Pms.Domain.Common.Enums;

namespace Pms.Application.Commands.Client.RegisterClientUser;

public class RegisterClientUserCommandResponse : BaseCommandResponse
{
    public string AccessToken { get; set; }
    public string UserName { get; set; }
    public string UserUxId { get; set; }
    public string ClientUxId { get; set; }

    public RegisterClientUserCommandResponse(bool succeed, ErrorCodes? errorCode = null) : base(succeed, errorCode)
    {

    }
}