using MediatR;
using Pms.Domain.Common.Enums;
using Pms.Domain.Interfaces;

namespace Pms.Application.Commands.Authenticate.AddUser;

public class AddUserCommandHandler : IRequestHandler<AddUserCommand, AddUserCommandResponse>
{
    private readonly IIdentityService _identityService;

    public AddUserCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }


    public async Task<AddUserCommandResponse> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var createdUser = await _identityService.GenerateUser(request.UserName, request.Password, request.IsActive);

        if (createdUser == null) return new AddUserCommandResponse(false, ErrorCodes.CreateUserFailed);

        return new AddUserCommandResponse(true)
        {
            UserName = createdUser.UserName,
            UserUxId = createdUser.UxId,
        };
    }
}