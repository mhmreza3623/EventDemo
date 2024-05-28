using Pms.Application.Dtos.ExternalService.Kariz.Responses;
using Pms.Domain.Common.Enums;

namespace Pms.Application.Commands.OnlinePayment.ProxyPayaTransfer
{
    public class ProxyPayaTransferCommandResponse : BaseCommandResponse
    {
        public ProxyPayaTransferCommandResponse(bool succeed, KarizProxyPayaTransferResponse result, ErrorCodes? errorCode = null) : base(succeed, errorCode)
        {
            Result = result;
        }

        public KarizProxyPayaTransferResponse Result { get; }
    }
}
