using MediatR;
using Pms.Application.Queries;
using Pms.Domain.Common.Enums;
using Pms.Domain.DomainEvents;

namespace Pms.Application.Commands.Client.UpdateClientProviderCredential;

public class UpdateClientProviderCredentialCommandHandler : IRequestHandler<UpdateClientProviderCredentialCommand, UpdateClientProviderCredentialCommandResponse>
{
    private readonly IClientRepository _clientRepository;

    public UpdateClientProviderCredentialCommandHandler(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<UpdateClientProviderCredentialCommandResponse> Handle(UpdateClientProviderCredentialCommand request, CancellationToken cancellationToken)
    {
        var uxId = Guid.Parse(request.ClientUxId);

        var client = await _clientRepository.GetAsync(uxId);

        if (client == null)
        {
            return new UpdateClientProviderCredentialCommandResponse(false, null, ErrorCodes.NotFoundClient);
        }

        client.ProviderUsername = request.KarizUsername;
        client.ProviderPassword = request.KarizPassword;
        client.Events.Add(new UpdateKarizCredentialClientEvent(client));

        await _clientRepository.UpdateAsync(client);

        return new UpdateClientProviderCredentialCommandResponse(true, uxId);
    }
}