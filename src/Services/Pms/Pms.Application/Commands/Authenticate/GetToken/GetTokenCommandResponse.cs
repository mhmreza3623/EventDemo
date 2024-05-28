using Pms.Domain.Common.Enums;

namespace Pms.Application.Commands.Authenticate.GetToken;

public class GetTokenCommandResponse : BaseCommandResponse
{
    public GetTokenCommandResponse(bool succeed, ErrorCodes? errorCode = null) : base(succeed, errorCode)
    {
    }

    public string AccessToken { get; set; }
}