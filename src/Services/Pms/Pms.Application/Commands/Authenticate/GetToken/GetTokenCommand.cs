using MediatR;

namespace Pms.Application.Commands.Authenticate.GetToken
{
    public class GetTokenCommand : IRequest<GetTokenCommandResponse>
    {
        public string UserName { get; set; }
        public string ClientUxId { get; set; }
    }
}
