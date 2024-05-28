using MediatR;
using Pms.Domain.DomainEvents;
using Pms.Domain.Repositories;

namespace Pms.Application.Commands.Client.RegisterClient;

public class RegisterClientCommandHandler : IRequestHandler<RegisterClientCommand, RegisterClientCommandResponse>
{
    private readonly IGeneralSqlRepository<Domain.Entities.Client> _clientRepository;

    public RegisterClientCommandHandler(IGeneralSqlRepository<Domain.Entities.Client> clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<RegisterClientCommandResponse> Handle(RegisterClientCommand request, CancellationToken cancellationToken)
    {
        var newClient = new Domain.Entities.Client()
        {
            Name =
            request.Name,
            DisplayName = request.DisplayName,
            Ips = request.Ips,
            IsActive = true,
            UxId = Guid.NewGuid(),
            DpkUserName = request.DpkUserName,
            DpkPassword = request.DpkPassword,

        };
        newClient.Events.Add(new CreatedClientEvent(newClient));

        await _clientRepository.InsertAsync(newClient);

        return new RegisterClientCommandResponse(true, newClient.UxId);
    }
}