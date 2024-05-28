using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pms.APIs.Configs.Filters;
using Pms.Application.Commands.Client.RegisterClient;
using Pms.Application.Commands.Client.UpdateClientDpkCredential;
using Pms.Application.Commands.Client.UpdateClientProviderCredential;
using Pms.Application.Dtos.Api.Clients;

namespace Pms.APIs.Api
{
    [Authorize]
    [IdentifyClient]
    public class ClientController : BaseV1Controller
    {
        private readonly IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterClient(RegisterClientRequest request)
        {
            var client = Client;
            var response = await _mediator.Send(new RegisterClientCommand(request.Name, request.DisplayName, request.DpkUsername, request.DpkPassword, request.Ips, request.KarizUsername, request.KarizPassword));

            return Ok(response);
        }

        [HttpPost("updateDpkCredential")]
        public async Task<IActionResult> UpdateClientKarizCredential(UpdateClientCredentialRequest request)
        {
            var response = await _mediator.Send(new UpdateClientDpkCredentialCommand(request.ClientUxId, request.Username, request.Password));

            return Ok(response);

        }

        [HttpPost("updateProviderCredential")]
        public async Task<IActionResult> UpdateClientDpkCredential(UpdateClientCredentialRequest request)
        {
            var response = await _mediator.Send(new UpdateClientProviderCredentialCommand(request.ClientUxId, request.Username, request.Password));

            return Ok(response);
        }
    }
}
