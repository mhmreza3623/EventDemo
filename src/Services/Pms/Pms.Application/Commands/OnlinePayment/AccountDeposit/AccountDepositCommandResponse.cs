using Pms.Application.Dtos.ExternalService.Kariz.Responses;
using Pms.Domain.Common.Enums;

namespace Pms.Application.Commands.OnlinePayment.AccountDeposit;

public class AccountDepositCommandResponse : BaseCommandResponse
{
    public AccountDepositCommandResponse(bool succeed, KarizAccountDepositResponse result, ErrorCodes? errorCode = null) : base(succeed, errorCode)
    {
        Result = result;
    }

    public KarizAccountDepositResponse Result { get; }
}
