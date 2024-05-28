using Pms.Domain.Common.Enums;

namespace Pms.Application.Commands.Client.UpdateClientDpkCredential;

public class UpdateClientDpkCredentialCommandResponse : BaseCommandResponse
{
    public Guid? ClientUxId { get; }

    public UpdateClientDpkCredentialCommandResponse(bool succeed, Guid? clientUxId, ErrorCodes? errorCode = null) : base(succeed, errorCode)
    {
        ClientUxId = clientUxId;
    }
}