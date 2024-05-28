using MediatR;

namespace Pms.Application.Commands.Authenticate.GetToken
{
    public class GetTokenCommand : IRequest<GetTokenCommandResponse>
    {
        public string UserUxId { get; set; }
    }
}
