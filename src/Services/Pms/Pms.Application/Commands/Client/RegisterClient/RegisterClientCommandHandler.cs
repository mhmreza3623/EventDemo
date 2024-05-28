using MediatR;
using Pms.Domain.Events;
using Pms.Domain.Repositories;

namespace Pms.Application.Commands.Client.RegisterClient;

public class RegisterClientCommandHandler : IRequestHandler<RegisterClientCommand, RegisterClientCommandResponse>
{
    private readonly IGeneralSqlRepository<Domain.Entities.Client> _clientRepository;
    private readonly IMediator _mediator;

    public RegisterClientCommandHandler(IGeneralSqlRepository<Domain.Entities.Client> clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<RegisterClientCommandResponse> Handle(RegisterClientCommand request, CancellationToken cancellationToken)
    {
        var newClient = Domain.Entities.Client.CreateClient(request.Name, request.DisplayName, true,
            request.DpkUserName, request.DpkPassword, request.ProviderUsename, request.ProviderPassword, request.Ips);

        await _clientRepository.InsertAsync(newClient);

        return new RegisterClientCommandResponse(true, newClient.UxId);
    }
}