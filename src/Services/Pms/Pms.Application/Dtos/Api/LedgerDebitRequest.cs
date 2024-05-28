namespace Pms.Application.Dtos.Api;

public class LedgerDebitRequest
{

    //کد شعبه	
    public string FcBranchNo { get; set; }

    //کد حساب دفتر کل
    public string LedgerCode { get; set; }
    //شماره حساب
    public string AccountNumber { get; set; }

    //میزان بدهی
    public string DebitAmount { get; set; }

    //معادل ارزی مبلغ اعتبار
    public string KdEquiv { get; set; }

    //منبع نرخ ارز
    public string FxRate { get; set; }

    //کد ارز
    public string CurrencyCode { get; set; }

    //مشتری
    public string OfficerId { get; set; }

    //نشان دهنده استاندارد بودن یا نبودن نرخ ارز با مقادیر 1 یا 0 است
    public string StandardFlag { get; set; }

    //کد ارز
    public string FundCurrency { get; set; }

    //شناسه فروشنده
    public string DealerId { get; set; }

    //کد مرجع معامله
    public string DealerReference { get; set; }

    // کلید مبدا 
    public string OriginKey { get; set; }

    //توضیحات
    public string Description { get; set; }

    //نظر لجر
    public string LedgerComment { get; set; }

    //نوع زبان
    public string LanguageType { get; set; }

    //زمان معامله
    public string TransactionTime { get; set; }

    //تاریخ معامله
    public string TransactionDate { get; set; }

    //اطلاعات دلخواه.
    public string SequenceNo { get; set; }
    //شناسه مرجع برای پیگیری تراکنش
    public string ReferenceId { get; set; }

}
