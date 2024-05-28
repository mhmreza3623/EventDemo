﻿using MediatR;
using Microsoft.Extensions.Options;
using Pms.Application.Queries;
using Pms.Domain.Common.Enums;
using Pms.Domain.Interfaces;
using SharedKernel.Common;

namespace Pms.Application.Commands.Authenticate.RegisterClientUser;

public class RegisterClientUserCommandHandler : IRequestHandler<RegisterClientUserCommand, RegisterClientUserCommandResponse>
{

    public RegisterClientUserCommandHandler(IIdentityService identityService,
        IClientRepository clientRepository)
    {
        _identityService = identityService;
        _clientRepository = clientRepository;
    }

    private readonly IIdentityService _identityService;
    private readonly IClientRepository _clientRepository;

    public async Task<RegisterClientUserCommandResponse> Handle(RegisterClientUserCommand command, CancellationToken cancellationToken)
    {
        var oldUser = await _identityService.GetUser(command.UserName);
        if (oldUser != null)
        {
            return new RegisterClientUserCommandResponse(false, ErrorCodes.DuplicateUser);
        }

        var clientUxId = command.ClientUxId;
        var client = await _clientRepository.GetAsync(Guid.Parse(clientUxId));
        if (client == null)
        {
            return new RegisterClientUserCommandResponse(false, ErrorCodes.NotFoundClient);
        }

        var createdUser = await _identityService.GenerateUser(command.UserName, command.Password, command.IsActive, client);

        if (createdUser == null) return new RegisterClientUserCommandResponse(false, ErrorCodes.CreateUserFailed);

        var token = _identityService
            .GenerateToken(createdUser.UserName, clientUxId);

        return new RegisterClientUserCommandResponse(true)
        {
            UserName = createdUser.UserName,
            AccessToken = token,
            ClientUxId = clientUxId.ToString(),
            UserUxId = createdUser.UxId.ToString(),
        };
    }

}