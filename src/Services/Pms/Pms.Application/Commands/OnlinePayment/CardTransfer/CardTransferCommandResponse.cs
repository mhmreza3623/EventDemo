using Pms.Application.Dtos.ExternalService.Kariz.Responses;
using Pms.Domain.Common.Enums;

namespace Pms.Application.Commands.OnlinePayment.CardTransfer;
/// <summary>
/// نتیجه تراکنش انتقال کارت به کارت
/// </summary>
public class CardTransferCommandResponse : BaseCommandResponse
{
    public CardTransferCommandResponse(bool succeed, KarizIsoCardTransferResponse result, ErrorCodes? errorCode = null) : base(succeed, errorCode)
    {
        Result = result;
    }

    public KarizIsoCardTransferResponse Result { get; }
}