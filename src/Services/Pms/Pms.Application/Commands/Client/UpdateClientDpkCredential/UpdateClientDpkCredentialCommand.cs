using MediatR;

namespace Pms.Application.Commands.Client.UpdateClientDpkCredential;

public class UpdateClientDpkCredentialCommand : IRequest<UpdateClientDpkCredentialCommandResponse>
{
    public string ClientUxId { get; }
    public string DpkUsername { get; }
    public string DpkPassword { get; }

    public UpdateClientDpkCredentialCommand(string clientUxId, string dpkUsername, string DpkPassword)
    {
        ClientUxId = clientUxId;
        DpkUsername = dpkUsername;
        this.DpkPassword = DpkPassword;
    }
}