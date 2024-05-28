using Pms.Domain.Common.Enums;

namespace Pms.Application.Commands.Authenticate.VerifyToken;

public class VerifyTokenCommandResponse:BaseCommandResponse
{
    public VerifyTokenCommandResponse(bool succeed, ErrorCodes? errorCode = null) : base(succeed, errorCode)
    {
    }

    public string ClientName { get; set; }
    public string DisplayName { get; set; }
    public Guid ClientUxId { get; set; }
    public long Id { get; set; }
    public bool IsActive { get; set; }
}