namespace Pms.Application.Dtos.ExternalService.Kariz.Responses;
/// <summary>
/// نتیجه تراکنش انتقال کارت به کارت
/// </summary>
public class KarizIsoCardTransferResponse : KarizBaseResponse
{
    /// <summary>
    /// شماره کارت
    /// </summary>
    public string SrcPan { get; set; }
    /// <summary>
    /// مبلغ تراکنش
    /// </summary>
    public long Amount { get; set; }
    /// <summary>
    ///شماره پیگیری ثبت
    /// وقایع در سیستم
    /// </summary>
    public string Stan { get; set; }
    /// <summary>
    ///شماره مرجع تراکنش
    /// </summary>
    public string RetrievalReferenceNumber { get; set; }
    /// <summary>
    ///تاریخ و زمان ارسال دادهها به سوئیچ
    /// </summary>
    public string TransmissionDateTime { get; set; }
    /// <summary>
    ///تاریخ و زمان انجام تراکنش به وقت محلی
    /// </summary>
    public string TransactionLocalTime { get; set; }
    /// <summary>
    ///تاریخ روز مالی
    /// </summary>
    public string CaptureDate { get; set; }
    /// <summary>
    /// کد شناسایی بانک یا سازمان پرداخت کننده
    /// </summary>
    public string AcquiringInstId { get; set; }
    /// <summary>
    ///نام
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    ///نام خانوادگی
    /// </summary>
    public string lastName { get; set; }

    /// <summary>
    /// اطلاعات مانده کارت
    /// </summary>
    //[CanBeNull]
    public CardBalance[]? Balance { get; set; }

}

public class CardBalance
{
    /// <summary>
    ///  نوع حساب :
    /// 00 : برای حساب های shadow
    /// 01 : جاری
    /// 02 : پس انداز
    /// 03 : کوتاه مدت
    /// </summary>
    public string AccountType { get; set; }
    /// <summary>
    ///  نوع مانده 
    /// </summary>
    public string BalanceType { get; set; }
    /// <summary>
    /// 364 : IRR
    /// </summary>
    public string CurrencyCode { get; set; }
    /// <summary>
    /// مقدار مانده کارت
    /// </summary>
    public long Balance { get; set; }

}

