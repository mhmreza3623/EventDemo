using Grpc.Core;
using MediatR;
using Pms.APIs.Protos;
using Pms.Application.Commands.Client.RegisterClient;
using Pms.Application.Commands.Client.UpdateClientDpkCredential;
using Pms.Application.Commands.Client.UpdateClientProviderCredential;

namespace Pms.APIs.Implementations
{
    public class ClientImplementation : ClientService.ClientServiceBase
    {
        private readonly IMediator _mediator;

        public ClientImplementation(IMediator mediator)
        {
            _mediator = mediator;
        }
        public override async Task<registerClientResponse> RegisterClient(registerClientRequest request, ServerCallContext context)
        {
            var response = await _mediator.Send(new RegisterClientCommand(request.Name, request.DisplayName, request.DpkUserName, request.DpkPassword, request.Ips, request.KarizUsername, request.ProviderPassword));

            return new registerClientResponse()
            {
                Succeed = response.Succeed,
                ClientUxId = response.ClientUxId.ToString()
            };
        }

        public override async Task<updateCredentialResponse> UpdateKarizCredential(updateCredentialRequest request,
            ServerCallContext context)
        {
            var response =
                await _mediator.Send(new UpdateClientProviderCredentialCommand(request.ClientUxId, request.Username,
                    request.Password));

            return new updateCredentialResponse()
            {
                Succeed = response.Succeed,
                ClientUxId = response.ClientUxId.ToString()
            };

        }

        public override async Task<updateCredentialResponse> UpdateDpkCredential(updateCredentialRequest request, ServerCallContext context)
        {
            var response = await _mediator.Send(new UpdateClientDpkCredentialCommand(request.ClientUxId, request.Username, request.Password));
            return new updateCredentialResponse()
            {
                Succeed = response.Succeed,
                ClientUxId = response.ClientUxId.ToString()
            };
        }
    }
}
