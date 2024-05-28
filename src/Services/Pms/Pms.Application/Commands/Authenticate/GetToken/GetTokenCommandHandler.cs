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
        var user = await _identityService.GetUserByUxId(Guid.Parse(command.UserUxId));
        if (user is null)
        {
            return new GetTokenCommandResponse(false, ErrorCodes.InvalidUser);
        }

        var token = _identityService.GenerateToken(user.UserName, 1450);

        var principal = _identityService.GetPrincipal(token);

        return new GetTokenCommandResponse(true)
        {
            AccessToken = token,
        };
    }
}