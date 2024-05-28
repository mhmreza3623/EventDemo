using Pms.Application.Dtos.ExternalService.Kariz.Responses;
using Pms.Domain.Common.Enums;

namespace Pms.Application.Commands.OnlinePayment.AccountWithdraw;

public class AccountWithdrawCommandResponse : BaseCommandResponse
{
    public AccountWithdrawCommandResponse(bool succeed, KarizAccountWithdrawResponse result, ErrorCodes? errorCode = null) : base(succeed, errorCode)
    {
        Result = result;
    }

    public KarizAccountWithdrawResponse Result { get; }
}