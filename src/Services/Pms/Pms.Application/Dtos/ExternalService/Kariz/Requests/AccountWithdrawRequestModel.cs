namespace Pms.Application.Dtos.ExternalService.Kariz.Requests;

public class AccountWithdrawRequestModel : AdanicApiBaseRequestModel
{
    public string Branch { get; set; }
    //مقدار تراکنش.
    public string Amount { get; set; }

    //مبلغ معادل ریالی	
    public string KdEquiv { get; set; }

    //شماره چک	
    public string CheqNo { get; set; }

    //تاریخ چک	
    public string CheqDate { get; set; }

    //کد سه رقمی مشخص کننده‌ی نوع تراکنش در صورت حساب
    public string StatDesc { get; set; }

    //کد زبان
    //persian is 'ف' for latin is 'ل'
    public string LangCode { get; set; }

    //نوع شارژ
    //can be 'ب' or 'خ'. Default is 'خ'.
    public string ChargeCode { get; set; }

    /// <summary>
    /// تنها زمانی که قصد برگشت زدن تراکنش را دارید با مقدار دریافتی از خروجی تراکنشی که می‌خواهید برگشت بزنید پر کنید.
    /// </summary>
    public string OriginKey { get; set; }

    //کد ملی	
    public string NationalId { get; set; }

    //اطلاعات اضافی ۲
    public string OptInfo15 { get; set; }

    //اطلاعات اضافی ۱
    public string OptInfo30 { get; set; }

    //زمان تراکنش
    public string TransactionTime { get; set; }
    public string TransactionDate { get; set; }

    //تاریخ اجرا
    public string RunDate { get; set; }

    //نام بانک مقصد
    public string CrBank { get; set; }

    //شماره حساب مقصد
    public string CrAccNo { get; set; }

    //کد شعبه مقصد
    public string CrBranch { get; set; }

    //نام خانوادگی گیرنده
    public string CrName1 { get; set; }

    //نام گیرنده
    public string CrName2 { get; set; }

    //کد اقتصادی گیرنده
    public string CrEconomicCode { get; set; }

    //کد پستی گیرنده
    public string CrPostCode { get; set; }

    //شماره تلفن گیرنده
    public string CrPhoneNo { get; set; }

    //شناسه پرداخت
    public string PayOpt { get; set; }

    //اطلاعات دلخواه
    public string SequenceNo { get; set; }
}
