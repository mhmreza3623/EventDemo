namespace Pms.Application.Dtos.Api;
/// <summary>
///  تمامی مقادیر باید مانند مقادیر ارسالی برای تراکنش انتقالی که نیاز به برگشت زدن است باشد
/// </summary>
public class IsoReverseCardTransferRequest
{
    /// <summary>
    /// شماره کارت مبدا
    /// </summary>
    public string Pan { get; set; }
    /// <summary>
    /// شماره کارت مقصد
    /// </summary>
    public string DstPan { get; set; }
    /// <summary>
    /// مبلغ تراکنش
    /// </summary>
    public long Amount { get; set; }
    /// <summary>
    /// شماره مرجع تراکنش
    /// </summary>
    public string RetrievalReferenceNumber { get; set; }
    /// <summary>
    /// شماره پیگیری ثبت
    ///وقایع در سیستم
    /// </summary>
    public long Stan { get; set; }
    /// <summary>
    /// زمان تراکنش
    /// The transactionTime of the transaction needed to be reversed
    /// HHmmss
    /// </summary>
    public string TransactionLocalTime { get; set; }

    /// <summary>
    /// تاریخ تراکنش
    /// The transactionDate of the transaction needed to be reversed
    /// MMDD
    /// </summary>
    public string TransactionLocalDate { get; set; }

    //شناسه مرجع برای پیگیری تراکنش
    public string ReferenceId { get; set; }


}



