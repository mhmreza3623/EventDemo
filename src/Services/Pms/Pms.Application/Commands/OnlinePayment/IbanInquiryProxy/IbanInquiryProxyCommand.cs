namespace Pms.Application.Commands.OnlinePayment.IbanInquiryProxy;

public class IbanInquiryProxyCommand : BaseOnlinePaymentCommand<IbanInquiryProxyCommandResponse>
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