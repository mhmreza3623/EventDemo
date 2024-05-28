namespace Pms.Application.Commands.OnlinePayment.ProxyInquiry;

public class ProxyInquiryCommand : BaseOnlinePaymentCommand<KarizProxyInquiryCommandResponse>
{
    /// <summary>
    /// تاریخ تراکنش باید بصورا زیر باشد
    /// Transaction date for example 1394/06/05 must set as 940605 YYMMDD
    /// </summary>
    public string Date { get; set; }
    /// <summary>
    /// زمان تراکنش باید بصورت زیر باشد
    /// Transaction time for example 11:40:34 must set as 114034
    /// </summary>
    public string Time { get; set; }
    /// <summary>
    /// فلگ وضعیت تراکنش
    /// N==>Normal
    /// R==>Reversal
    /// I==>Inflight
    /// </summary>
    public string StatusFlag { get; set; }
    /// <summary>
    /// شماره ترتیب
    /// </summary>
    public string FcSeqNo { get; set; }
    /// <summary>
    /// شماره چک
    /// 10 رقم
    /// </summary>
    public string CheqNo { get; set; }
    /// <summary>
    ///کد بانک
    /// 2 حرقی
    /// </summary>
    public string BankCode { get; set; }
    //شناسه مرجع برای پیگیری تراکنش
    public string ReferenceId { get; set; }
}