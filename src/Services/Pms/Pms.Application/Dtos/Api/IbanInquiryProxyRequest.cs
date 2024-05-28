namespace Pms.Application.Dtos.Api;
public class IbanInquiryProxyRequest
{
    /// <summary>
    /// شماره شبا
    /// </summary>
    public string Iban { get; set; }
    /// <summary>
    /// شناسه واریز
    /// </summary>
    public string PayId { get; set; }

    public string ReferenceId { get; set; }
}

