using Pms.Application.Dtos.ExternalService.Kariz.Responses;
using Pms.Domain.Common.Enums;

namespace Pms.Application.Commands.OnlinePayment.LedgerCredit;

public class LedgerCreditCommandResponse : BaseCommandResponse
{
    public LedgerCreditCommandResponse(bool succeed, KarizLedgerCreditResponse result, ErrorCodes? errorCode = null) : base(succeed, errorCode)
    {
        Result = result;
    }

    public KarizLedgerCreditResponse Result { get; }
}
