namespace Pms.Application.Dtos.ExternalService.Kariz.Requests;
public class CardTransferRequestModel : AdanicBasePostModel
{
    /// <summary>
    /// شماره کارت
    /// 16 رقم یا 19 رقم
    /// </summary>
    public string SrcPan { get; set; }
    /// <summary>
    /// شماره کارت مقصد
    /// 16 رقم یا 19 رقم
    /// </summary>
    public string DstPan { get; set; }
    /// <summary>
    ///شماره پیگیری ثبت
    /// وقایع در سیستم
    /// 6 رقم
    /// </summary>
    public string Stan { get; set; }
    /// <summary>
    /// مبلغ تراکنش
    /// </summary>
    public long Amount { get; set; }
    /// <summary>
    ///شماره مرجع تراکنش
    /// 12 رقم
    /// </summary>
    public string RetrievalReferenceNumber { get; set; }
    /// <summary>
    /// شناسه پرداخت
    ///  18 رقم
    /// </summary>
    public string PaymentId { get; set; }
    /// <summary>
    /// رمز دارنده کارت
    /// </summary>
    public string SecondPin { get; set; }
    /// <summary>
    ///تاریخ انقضاء کارت
    /// </summary>
    public string ExpDate { get; set; }
    /// <summary>
    /// Cvv2
    /// </summary>
    public string Cvv2 { get; set; }
}

