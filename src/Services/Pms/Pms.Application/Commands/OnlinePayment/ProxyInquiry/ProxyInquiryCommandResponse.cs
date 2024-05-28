using Pms.Application.Dtos.ExternalService.Kariz.Responses;
using Pms.Domain.Common.Enums;

namespace Pms.Application.Commands.OnlinePayment.ProxyInquiry;
public class KarizProxyInquiryCommandResponse : BaseCommandResponse
{
    public KarizProxyInquiryCommandResponse(bool succeed, KarizProxyInquiryResponse result, ErrorCodes? errorCode = null) : base(succeed, errorCode)
    {
        Result = result;
    }

    public KarizProxyInquiryResponse Result { get; }
}

