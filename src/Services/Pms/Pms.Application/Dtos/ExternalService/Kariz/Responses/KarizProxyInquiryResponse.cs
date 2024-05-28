namespace Pms.Application.Dtos.ExternalService.Kariz.Responses;
public class KarizProxyInquiryResponse : KarizBaseResponse
{

    /// <summary>
    /// نتیجه تراکنش
    /// Y==>تراکنش انجام شده
    /// N==>هیچ گزارش تراکنش وجود نداشت
    /// </summary>
    public string TransactionLogIndex { get; set; }

    public string CicsXT { get; set; }
    /// <summary>
    /// کد خطا
    /// </summary>
    public string AlertCode { get; set; }
    /// <summary>
    /// شرح کد خطا
    /// </summary>
    public string MessageOut { get; set; }
}

