using Pms.Application.Dtos.ExternalService.Kariz.Responses;
using Pms.Domain.Common.Enums;

namespace Pms.Application.Commands.OnlinePayment.IbanInquiryProxy;
public class IbanInquiryProxyCommandResponse : BaseCommandResponse
{
    public IbanInquiryProxyCommandResponse(bool succeed, KarizIbanInquiryProxyResponse result, ErrorCodes? errorCode = null) : base(succeed, errorCode)
    {
        Result = result;
    }

    public KarizIbanInquiryProxyResponse Result { get; }
}

