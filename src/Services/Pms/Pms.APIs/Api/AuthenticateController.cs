using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Pms.Application.Commands.Authenticate.GetToken;
using Pms.Application.Commands.Authenticate.RegisterClientUser;
using Pms.Application.Dtos.Api.Authenticate;
using Pms.Application.Dtos.Api.Clients;

namespace Pms.APIs.Api
{
    [AllowAnonymous]
    public class AuthenticateController : BaseV1Controller
    {
        private readonly IMediator _mediator;

        public AuthenticateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("user/add")]
        public async Task<IActionResult> RegisterUser(RegisterUserRequest request)
        {
            await _mediator.Send(new RegisterClientUserCommand(request.UserName, request.Password, request.IsActive, request.ClientUxId));

            return Ok();
        }

        [Authorize]
        [HttpPost("getToken")]
        public async Task<IActionResult> GetToken(GetTokenRequest request)
        {
            var response = await _mediator.Send(new GetTokenCommand()
            {
                UserName = request.UserName,
                ClientUxId = request.ClientUxId,
            });

            return Ok(response);
        }
    }
}
