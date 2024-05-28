using MediatR;
using Pms.Application.Queries;
using Pms.Domain.Common.Enums;
using Pms.Domain.Interfaces;

namespace Pms.Application.Commands.Authenticate.GetToken;

public class GetTokenCommandHandler : IRequestHandler<GetTokenCommand, GetTokenCommandResponse>
{
    private readonly IIdentityService _identityService;
    private readonly IClientRepository _clientRepository;

    public GetTokenCommandHandler(IIdentityService identityService, IClientRepository clientRepository)
    {
        _identityService = identityService;
        _clientRepository = clientRepository;
    }
    public async Task<GetTokenCommandResponse> Handle(GetTokenCommand command, CancellationToken cancellationToken)
    {
        var oldUser = await _identityService.GetUser(command.UserName);
        if (oldUser == null)
        {
            return new GetTokenCommandResponse(false, ErrorCodes.DuplicateUser);
        }

        var clientUxId = oldUser.Client.UxId;
        if (clientUxId.ToString().ToLower() != command.ClientUxId.ToLower())
        {
            return new GetTokenCommandResponse(false, ErrorCodes.InvalidClientId);
        }

        var client = await _clientRepository.GetAsync(clientUxId);
        if (client == null)
        {
            return new GetTokenCommandResponse(false, ErrorCodes.NotFoundClient);
        }

        var token = _identityService.GenerateToken(command.UserName, clientUxId.ToString(), 2);
        var principal = _identityService.GetPrincipal(token);

        return new GetTokenCommandResponse(true)
        {
            AccessToken = token,
        };
    }
}