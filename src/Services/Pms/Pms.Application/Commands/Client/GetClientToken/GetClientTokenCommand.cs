using MediatR;

namespace Pms.Application.Commands.Client.GetClientToken
{
    public class GetClientTokenCommand : IRequest<GetClientTokenCommandResponse>
    {
        public string UserName { get; set; }
        public string ClientUxId { get; set; }
    }
}
