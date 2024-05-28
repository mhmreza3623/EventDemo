using Pms.Application.Dtos.ExternalService.Kariz.Responses;
using Pms.Domain.Common.Enums;

namespace Pms.Application.Commands.OnlinePayment.SatnaTransfer
{
    public class SatnaTransferCommandResponse : BaseCommandResponse
    {
        public SatnaTransferCommandResponse(bool succeed, KarizSatnaTransferResponse result, ErrorCodes? errorCode = null) : base(succeed, errorCode)
        {
            Result = result;
        }

        public KarizSatnaTransferResponse Result { get; }
    }
}
