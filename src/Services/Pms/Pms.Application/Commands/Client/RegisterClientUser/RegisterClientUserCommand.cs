using MediatR;

namespace Pms.Application.Commands.Client.RegisterClientUser
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

        public string ClientUxId { get; }
        public string UserName { get; }
        public string Password { get; }
        public bool IsActive { get; }
    }
}
