namespace Pms.Application.Commands.OnlinePayment.AccountDeposit
{

    public class AccountDepositCommand : BaseOnlinePaymentCommand<AccountDepositCommandResponse>
    {

        //شماره حساب
        public string AccountNumber { get; set; }

        //شناسه مرجع برای پیگیری تراکنش
        public string ReferenceId { get; set; }

        //معادل ارزی مبلغ بدهکار
        public string KdEquiv { get; set; }

        //مبلغ سپرده
        public string Amount { get; set; }

        //کد زبان فارسی "ف" برای لاتین "ل" است
        public string LangCode { get; set; }

        /// <summary>
        /// نوع شارژ را تعریف می کند و می تواند "ب" یا "خ" باشد
        /// </summary>
        public string ChargeCode { get; set; }

        /// <summary>
        /// اگر می‌خواهید تراکنش را معکوس کنید، آن را پر کنید، در غیر این صورت مقداری برای آن تعیین نکنید
        /// </summary>
        public string OriginKey { get; set; }

        //کد ملی
        public string Nid { get; set; }

        //شرح معامله
        public string StatDesc { get; set; }

        //اطلاعات دلخواه.
        public string OptInfo1 { get; set; }

        //اطلاعات دلخواه.
        public string OptInfo2 { get; set; }

        //زمان معامله
        /// <summary>
        /// For example 14:52:48 must be set as 145248
        /// </summary>
        public string TransactionTime { get; set; }

        //تاریخ معامله
        /// <summary>
        /// For example 1370/04/07 must be set as 700407
        /// </summary>
        public string TransactionDate { get; set; }

        //اطلاعات دلخواه
        /// <summary>
        /// اگر می خواهید بعداً تراکنش را استعلام کنید، بهتر است خودتان آن را تنظیم کنید وگرنه کاریز آن را تنظیم می کند. حداکثر مقدار می تواند 9999 باشد
        /// </summary>
        public string SequenceNo { get; set; }

        //شماره پین ​​حساب
        public string Pin { get; set; }

    }
}
