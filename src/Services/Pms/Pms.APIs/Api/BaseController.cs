using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Pms.Application.Dtos.Api.Authenticate;
using Pms.Application.Commands.Authenticate.AddUser;
using Pms.Application.Commands.Authenticate.GetToken;
using Pms.Application.Commands.Client.RegisterClientUser;
using Pms.Application.Dtos.Api.Clients;
using Pms.Application.Commands.Client.RegisterClient;

namespace Pms.APIs.Api
{
    public class BaseController : GeneralController
    {
        private readonly IMediator _mediator;

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("auth/addUser")]
        public async Task<IActionResult> AddUser(RegisterUserRequest request)
        {
            var response = await _mediator.Send(new AddUserCommand(request.UserName, request.Password, request.IsActive));

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("auth/getToken")]
        public async Task<IActionResult> GetToken(GetTokenRequest request)
        {
            var response = await _mediator.Send(new GetTokenCommand()
            {
                UserName = request.UserName,
                Password = request.Password
            });

            return Ok(response);
        }

        [HttpPost("client/register")]
        public async Task<IActionResult> RegisterClient(RegisterClientRequest request)
        {
            var response = await _mediator.Send(new RegisterClientCommand(request.Name, request.DisplayName, request.DpkUsername, request.DpkPassword, request.Ips, request.KarizUsername, request.KarizPassword));

            return Ok(response);
        }

        [HttpPost("client/assignUser")]
        public async Task<IActionResult> AssignUser(RegisterClientUserRequest request)
        {
            var response = await _mediator.Send(new RegisterClientUserCommand(request.UserName, request.Password, request.IsActive, request.ClientUxId));

            return Ok(response);
        }
    }
}
