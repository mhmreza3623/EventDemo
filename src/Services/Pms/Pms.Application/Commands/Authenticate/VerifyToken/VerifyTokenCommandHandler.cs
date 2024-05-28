using MediatR;
using Pms.Application.Queries;
using Pms.Domain.Common.Enums;
using Pms.Domain.Interfaces;

namespace Pms.Application.Commands.Authenticate.VerifyToken;

public class VerifyTokenCommandHandler:IRequestHandler<VerifyTokenCommand,VerifyTokenCommandResponse>
{
    private readonly IIdentityService _identityService;
    private readonly IClientRepository _clientRepository;

    public VerifyTokenCommandHandler(IIdentityService identityService,IClientRepository clientRepository)
    {
        _identityService = identityService;
        _clientRepository = clientRepository;
    }

    public async Task<VerifyTokenCommandResponse> Handle(VerifyTokenCommand command, CancellationToken cancellationToken)
    {
        var principal = _identityService.GetPrincipal(command.Token.Trim());
        if (principal == null)
        {
            return new VerifyTokenCommandResponse(false, ErrorCodes.InvalidToken);

        }
        var clientUxID=principal.Claims.SingleOrDefault(q => q.Type == "CUxID").Value;
        if (!Guid.TryParse(clientUxID, out var clientUxId))
        {
            return new VerifyTokenCommandResponse(false, ErrorCodes.NotFoundClient);
        }

        var client=await _clientRepository.GetAsync(clientUxId);

        return new VerifyTokenCommandResponse(true)
        {
            Id= client.Id,
            ClientName = client.Name,
            DisplayName= client.DisplayName,
            ClientUxId= client.UxId,
            IsActive= client.IsActive,
        };
    }
}