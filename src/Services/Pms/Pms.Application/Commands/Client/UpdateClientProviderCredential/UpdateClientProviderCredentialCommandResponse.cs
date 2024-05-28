using Pms.Domain.Common.Enums;

namespace Pms.Application.Commands.Client.UpdateClientProviderCredential;

public class UpdateClientProviderCredentialCommandResponse : BaseCommandResponse
{
    public Guid? ClientUxId { get; }

    public UpdateClientProviderCredentialCommandResponse(bool succeed, Guid? clientUxId, ErrorCodes? errorCode = null) : base(succeed, errorCode)
    {
        ClientUxId = clientUxId;
    }
}