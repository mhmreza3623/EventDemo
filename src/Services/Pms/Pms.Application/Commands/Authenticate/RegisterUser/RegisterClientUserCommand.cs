using MediatR;

namespace Pms.Application.Commands.Authenticate.RegisterClientUser
{
    public class RegisterClientUserCommand : IRequest<RegisterClientUserCommandResponse>
    {
        public RegisterClientUserCommand(string userName, string password, bool isActive, string clientUxId)
        {
            UserName = userName;
            Password = password;
            IsActive = isActive;
            ClientUxId = clientUxId;
        }

        public string ClientUxId { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public bool IsActive { get; private set; }
    }
}
