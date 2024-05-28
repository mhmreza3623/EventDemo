using Pms.Domain.Common.Enums;

namespace Pms.Application.Commands.Client.GetClientToken;

public class GetClientTokenCommandResponse : BaseCommandResponse
{
    public GetClientTokenCommandResponse(bool succeed, ErrorCodes? errorCode = null) : base(succeed, errorCode)
    {
    }

    public string AccessToken { get; set; }
}