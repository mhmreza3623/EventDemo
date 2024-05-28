using Pms.Application.Dtos.ExternalService.Kariz.Responses;
using Pms.Domain.Common.Enums;

namespace Pms.Application.Commands.OnlinePayment.IsoReverseCardTransfer;

public class IsoReverseCardTransferCommandResponse : BaseCommandResponse
{
    public IsoReverseCardTransferCommandResponse(bool succeed, KarizIsoReverseCardTransferResponse result, ErrorCodes? errorCode = null) : base(succeed, errorCode)
    {
        Result = result;
    }

    public KarizIsoReverseCardTransferResponse Result { get; }
}

