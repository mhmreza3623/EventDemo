using MediatR;

namespace Pms.Application.Commands.Authenticate.AddUser
{
    public class AddUserCommand : IRequest<AddUserCommandResponse>
    {
        public AddUserCommand(string username,string password,bool isActive)
        {
            UserName = username;
            Password = password;
            IsActive = isActive;
        }

        public string UserName { get;  }
        public string Password { get;  }
        public bool IsActive { get;  }
    }
}
