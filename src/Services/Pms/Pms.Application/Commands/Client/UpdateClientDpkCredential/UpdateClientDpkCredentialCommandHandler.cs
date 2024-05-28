using MediatR;
using Pms.Domain.Common.Enums;
using Pms.Domain.DomainEvents;
using Pms.Domain.Repositories;

namespace Pms.Application.Commands.Client.UpdateClientDpkCredential;

public class UpdateClientDpkCredentialCommandHandler : IRequestHandler<UpdateClientDpkCredentialCommand, UpdateClientDpkCredentialCommandResponse>
{
    private readonly IGeneralSqlRepository<Domain.Entities.Client> _clientRepository;

    public UpdateClientDpkCredentialCommandHandler(IGeneralSqlRepository<Domain.Entities.Client> clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<UpdateClientDpkCredentialCommandResponse> Handle(UpdateClientDpkCredentialCommand request, CancellationToken cancellationToken)
    {
        var uxId = Guid.Parse(request.ClientUxId);
        var client = await _clientRepository.GetAsync(uxId);

        if (client == null)
        {
            return new UpdateClientDpkCredentialCommandResponse(false, null, ErrorCodes.NotFoundClient);
        }

        client.DpkUserName = request.DpkUsername;
        client.DpkPassword = request.DpkPassword;
        client.Events.Add(new UpdateDpkCredentialClientEvent(client));

        await _clientRepository.UpdateAsync(client);

        return new UpdateClientDpkCredentialCommandResponse(true, uxId);
    }
}