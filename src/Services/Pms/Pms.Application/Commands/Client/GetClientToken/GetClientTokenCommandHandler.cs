using MediatR;
using Pms.Application.Commands.Authenticate.GetToken;
using Pms.Application.Queries;
using Pms.Domain.Common.Enums;
using Pms.Domain.Interfaces;

namespace Pms.Application.Commands.Client.GetClientToken;

public class GetClientTokenCommandHandler : IRequestHandler<GetClientTokenCommand, GetClientTokenCommandResponse>
{
    private readonly IIdentityService _identityService;
    private readonly IClientRepository _clientRepository;

    public GetClientTokenCommandHandler(IIdentityService identityService, IClientRepository clientRepository)
    {
        _identityService = identityService;
        _clientRepository = clientRepository;
    }
    public async Task<GetClientTokenCommandResponse> Handle(GetClientTokenCommand command, CancellationToken cancellationToken)
    {
        var oldUser = await _identityService.GetUser(command.UserName);
        if (oldUser == null)
        {
            return new GetClientTokenCommandResponse(false, ErrorCodes.DuplicateUser);
        }

        var clientUxId = oldUser.Client.UxId;
        if (clientUxId.ToString().ToLower() != command.ClientUxId.ToLower())
        {
            return new GetClientTokenCommandResponse(false, ErrorCodes.InvalidClientId);
        }

        var client = await _clientRepository.GetAsync(clientUxId);
        if (client == null)
        {
            return new GetClientTokenCommandResponse(false, ErrorCodes.NotFoundClient);
        }

        var token = _identityService.GenerateToken(command.UserName, 2);
        var principal = _identityService.GetPrincipal(token);

        return new GetClientTokenCommandResponse(true)
        {
            AccessToken = token,
        };
    }
}