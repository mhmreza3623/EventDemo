using Pms.Application.Dtos.ExternalService.Kariz.Responses;
using Pms.Domain.Common.Enums;

namespace Pms.Application.Commands.OnlinePayment.AccountTransfer
{
    public class AccountTransferCommandResponse : BaseCommandResponse
    {
        public AccountTransferCommandResponse(bool succeed, KarizAccountTransferResponse result, ErrorCodes? errorCode = null) : base(succeed, errorCode)
        {
            Result = result;
        }

        public KarizAccountTransferResponse Result { get; }
    }
}
