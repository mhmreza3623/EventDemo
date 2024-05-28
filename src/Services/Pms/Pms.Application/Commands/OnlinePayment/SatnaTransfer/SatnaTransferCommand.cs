namespace Pms.Application.Commands.OnlinePayment.SatnaTransfer;

public class SatnaTransferCommand : BaseOnlinePaymentCommand<SatnaTransferCommandResponse>
{
    /// <summary>
    /// کد شعبه‌ی عامل. به صورت پیش فرض برابر با کد شعبه مجازی ۸۰۰۰ مقدار دهی می‌شود.
    /// توجه کنید که مسئولیت تغییر کد شعبه از ۸۰۰۰ به عهده‌ی استفاده کننده از سرویس است.
    /// </summary>
    public string Branch { get; set; }
    /// <summary>
    /// شماره حساب مبدا تراکنش.
    /// </summary>
    public string Account { get; set; }
    /// <summary>
    /// 	مشخص کننده‌ی مرحله‌ی تراکنش
    /// تراکنش می‌تواند دو مرحله‌ی اجرای یا استعلام داشته باشد. در مرحله‌ی استعلام مبلغی انتقال داده
    /// نمی‌شود و استعلامات لازمه از شماره شبای مقصد و شناسه ی پرداخت در صورت وجود گرفته می شود
    /// لازم به ذکر است انجام مرحله‌ی استعلام برای تراکنش‌هایی با شناسه پرداخت در مقصد و تراکنش‌هایی با مقصد حساب نزد بانک مرکزی اجباری است.
    /// </summary>
    public string Mode { get; set; }
    /// <summary>
    ///مبلغ انتقالی (توجه کنید که با توجه به کارمزد،مبلغ انتقالی می‌تواند با مبلغ برداشته شده از حساب مبدا متفاوت باشد)
    /// </summary>
    public string Amount { get; set; }
    /// <summary>
    /// کد مشخص کننده‌ی نوع تراکنش در صورتحساب. برای مثال 008 معادل انتقالی
    /// </summary>
    public string StatDesc { get; set; }
    /// <summary>
    /// شاخص هزینه‌ی تراکنش
    /// ب: بله
    /// خ: خیر
    /// </summary>
    public string ChargeCode { get; set; }
    /// <summary>
    /// شماره چک
    /// </summary>
    public string ChqNo { get; set; }
    /// <summary>
    /// تاریخ چک. ۶ رقمی (در صورت وارد کردن شماره چک الزامی است)
    /// </summary>
    public string ChqDate { get; set; }
    /// <summary>
    /// کد ملی یا شناسه ملی مبدا تراکنش
    /// </summary>
    public string NationalId { get; set; }
    /// <summary>
    /// CTR شماره فرم
    /// </summary>
    public string CtrId { get; set; }
    /// <summary>
    /// شرح منشا پول
    /// </summary>
    public string MoneyOrigin { get; set; }
    /// <summary>
    /// کد اقتصادی شرکت مقصد (حقوقی)
    /// </summary>
    public string EconomicCodeN { get; set; }
    /// <summary>
    /// شاخص وجود شناسه پرداخت
    /// 0 عدم وجود
    /// 1 وجود شناسه
    /// </summary>
    public string ExistPayId { get; set; }
    /// <summary>
    /// 	شماره شبای مقصد
    /// </summary>
    public string CreditAccount { get; set; }
    /// <summary>
    /// کد شعبه مقصد
    /// </summary>
    public string CreditBranchCode { get; set; }
    /// <summary>
    /// 	نام صاحب حساب مقصد
    /// </summary>
    public string CreditorName { get; set; }
    /// <summary>
    /// نام خانوادگی صاحب حساب مقصد
    /// </summary>
    public string CreditorFamilyName { get; set; }
    /// <summary>
    /// کد ملی مقصد
    /// </summary>
    public string EconomicCode { get; set; }
    /// <summary>
    /// کد پستی گیرنده
    /// </summary>
    public string PostalCode { get; set; }
    /// <summary>
    /// 	تلفن گیرنده
    /// </summary>
    public string PhoneNumber { get; set; }
    /// <summary>
    /// شرح اضافی ۳۰ کاراکتری
    /// </summary>
    public string OptInfo1 { get; set; }
    /// <summary>
    /// شرح اضافی ۱۵ کاراکتری
    /// </summary>
    public string OptInfo { get; set; }
    /// <summary>
    /// 	کد زبان
    /// فارسی ف
    /// انگلیسی ل
    /// </summary>
    public string LangCode { get; set; }
    /// <summary>
    /// 	شناسه پرداخت
    /// </summary>
    public string PayId { get; set; }
    /// <summary>
    /// پین حساب. فقط برای کانال‌هایی که ورودی پین حساب برای آن‌ها اجباری تعیین شده نیاز به ارسال است.
    /// </summary>
    public string Pin { get; set; }
    /// <summary>
    /// Transaction date
    /// </summary>
    public string TransactionTime { get; set; }
    /// <summary>
    /// Transaction time
    /// </summary>
    public string TransactionDate { get; set; }
    /// <summary>
    /// This parameter is for inquiring the transaction
    /// </summary>
    public string SequenceNo { get; set; }
    //شناسه مرجع برای پیگیری تراکنش
    public string ReferenceId { get; set; }
}

