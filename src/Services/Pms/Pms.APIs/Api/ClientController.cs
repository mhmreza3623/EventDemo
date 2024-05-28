using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pms.APIs.Configs.Filters;
using Pms.Application.Commands.Client.GetClientToken;
using Pms.Application.Commands.Client.RegisterClient;
using Pms.Application.Commands.Client.RegisterClientUser;
using Pms.Application.Commands.Client.UpdateClientDpkCredential;
using Pms.Application.Commands.Client.UpdateClientProviderCredential;
using Pms.Application.Dtos.Api.Clients;

namespace Pms.APIs.Api
{
    [Authorize]
    public class ClientController : BaseV1Controller
    {
        private readonly IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("getToken")]
        public async Task<IActionResult> GetToken(GetClientTokenRequest request)
        {
            var response = await _mediator.Send(new GetClientTokenCommand()
            {
                UserName = request.UserName,
                ClientUxId = Client.ClientUxId.ToString()
            });

            return Ok(response);
        }

        [HttpPost("updateDpkCredential")]
        public async Task<IActionResult> UpdateClientKarizCredential(UpdateClientCredentialRequest request)
        {
            var response = await _mediator.Send(new UpdateClientDpkCredentialCommand(Client.ClientUxId.ToString(), request.Username, request.Password));

            return Ok(response);

        }

        [HttpPost("updateProviderCredential")]
        public async Task<IActionResult> UpdateClientDpkCredential(UpdateClientCredentialRequest request)
        {
            var response = await _mediator.Send(new UpdateClientProviderCredentialCommand(Client.ClientUxId.ToString(), request.Username, request.Password));

            return Ok(response);
        }
    }
}
