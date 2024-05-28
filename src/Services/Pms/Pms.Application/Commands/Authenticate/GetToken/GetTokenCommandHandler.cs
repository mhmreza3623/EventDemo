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
        var userIsValid = await _identityService.CheckPassword(command.UserName,command.Password);
        if (!userIsValid)
        {
            return new GetTokenCommandResponse(false, ErrorCodes.InvalidUser);
        }

        var token = _identityService.GenerateToken(command.UserName, 2);

        var principal = _identityService.GetPrincipal(token);

        return new GetTokenCommandResponse(true)
        {
            AccessToken = token,
        };
    }
}