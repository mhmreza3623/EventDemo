using Pms.Application.Dtos.ExternalService.Kariz.Responses;
using Pms.Domain.Common.Enums;

namespace Pms.Application.Commands.OnlinePayment.LedgerDebit;

public class LedgerDebitCommandResponse : BaseCommandResponse
{
    public LedgerDebitCommandResponse(bool succeed, KarizLedgerDebitResponse result, ErrorCodes? errorCode = null) : base(succeed, errorCode)
    {
        Result = result;
    }

    public KarizLedgerDebitResponse Result { get; }
}
