using MediatR;

namespace Pms.Application.Commands.Client.UpdateClientProviderCredential;

public class UpdateClientProviderCredentialCommand : IRequest<UpdateClientProviderCredentialCommandResponse>
{
    public string ClientUxId { get; }
    public string KarizUsername { get; }
    public string KarizPassword { get; }

    public UpdateClientProviderCredentialCommand(string clientUxId, string karizUsername, string karizPassword)
    {
        ClientUxId = clientUxId;
        KarizUsername = karizUsername;
        KarizPassword = karizPassword;
    }
}