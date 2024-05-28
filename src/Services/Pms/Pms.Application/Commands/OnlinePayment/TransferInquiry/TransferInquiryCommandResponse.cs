using Pms.Application.Dtos.ExternalService.Kariz.Responses;
using Pms.Domain.Common.Enums;

namespace Pms.Application.Commands.OnlinePayment.TransferInquiry;
public class TransferInquiryCommandResponse : BaseCommandResponse
{
    public TransferInquiryCommandResponse(bool succeed, KarizTransferInquiryResponse result, ErrorCodes? errorCode = null) : base(succeed, errorCode)
    {
        Result = result;
    }

    public KarizTransferInquiryResponse Result { get; }
}

