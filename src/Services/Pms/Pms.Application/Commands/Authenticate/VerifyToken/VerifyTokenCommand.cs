using MediatR;

namespace Pms.Application.Commands.Authenticate.VerifyToken
{
    public class VerifyTokenCommand : IRequest<VerifyTokenCommandResponse>
    {
        public VerifyTokenCommand(string token)
        {
            Token = token;
        }

        public string Token { get; }
    }
}
