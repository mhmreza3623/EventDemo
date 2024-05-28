namespace Pms.Application.Dtos.ExternalService.Kariz.Requests;
public class IbanInquiryProxyRequestModel : AdanicBasePostModel
{
    /// <summary>
    /// شماره شبا
    /// </summary>
    public string Iban { get; set; }
    /// <summary>
    /// شناسه واریز
    /// </summary>
    public string PayId { get; set; }

}



