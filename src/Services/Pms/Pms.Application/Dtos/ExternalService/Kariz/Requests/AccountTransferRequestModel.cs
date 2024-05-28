namespace Pms.Application.Dtos.ExternalService.Kariz.Requests;

public class AccountTransferRequestModel : AdanicApiBaseRequestModel
{
    //کد شعبه عامل
    public string Branch { get; set; }

    //مبلغ تراکنش	
    public string DebitAmount { get; set; }

    //شماره حساب مقصد تراکنش	
    public string CreditAccount { get; set; }

    //شرح اختیاری ۱۵ کاراکتری
    public string DebitOpt15 { get; set; }

    //شرح اختیاری ۳۰ کاراکتری
    public string DebitOpt30 { get; set; }

    //اطلاعات تکمیلی	
    public string CreditOptInfo15 { get; set; }

    //اطلاعات تکمیلی
    public string CreditOptInfo30 { get; set; }

    //کد زبان
    /// <summary>
    /// ف: فارسی
    ///ل: لاتین
    /// </summary>
    public string LangCode { get; set; }

    //فلگ برگشت زدن تراکنش
    public string ReverseTransaction { get; set; }

    //شناسه‌ی تراکنش
    public string OriginKey { get; set; }

    //	شاخص هزینه‌ی تراکنش
    /// <summary>
    /// ب: بله
    /// خ: خیر
    /// </summary>
    public string ChargeCode { get; set; }

    //شاخص مشخص کننده‌ی تراکنش‌های بورسی
    /// <summary>
    /// Y: بله
    /// N: خیر
    /// </summary>
    public string BoursFlag { get; set; }

    //کد مشخص کننده‌ی نوع تراکنش در صورتحساب
    public string StatementCodeDescription { get; set; }

    //اطلاعات اضافی حساب بدهکار	
    public string DebtorAccountOptInfo { get; set; }

    //اطلاعات اضافی حساب بستانکار	
    public string CreditorAccountOptInfo { get; set; }

    //پین حساب
    public string Pin { get; set; }

    //زمان تراکنش
    public string TransactionTime { get; set; }

    //تاریخ تراکنش
    public string TransactionDate { get; set; }

    //شماره چک	
    public string CheqNo { get; set; }

    //تاریخ چک	
    public string CheqDate { get; set; }

    //کد ملی	
    public string NationalId { get; set; }

    //شماره فرم ctr	
    public string CtrId { get; set; }

    //منشا پول	
    public string OriginOfMoney { get; set; }

    //کد پستی	
    public string PostCode { get; set; }

    //شماره شبای ذینفع چک	
    public string BnfSheba { get; set; }

    //نوع مشتری ذینفع		
    public string BnfCustomerType { get; set; }

    //نوع حساب ذینفع		
    public string BnfAccountType { get; set; }

    //قلگ نوع شماره قراگیر		
    public string BnfIdStat { get; set; }

    //شماره فراگیر ذینفع		
    public string BnfId { get; set; }

    //شناسه واریز چک		
    public string BnfShenase { get; set; }

    //نام ذینفع		
    public string BnfName { get; set; }

    //نام خانوادگی ذینفع		
    public string BnfFamily { get; set; }

    //تاریخ تولد/صدور ذینفع		
    public string BnfDate { get; set; }

    //محل صدور/ثبت ذینفع		
    public string BnfCity { get; set; }

    //شماره ثبت شرکت ذینفع		
    public string BnfNum { get; set; }

    //آدرس ذینفع ۱		
    public string BnfAddress1 { get; set; }

    //آدرس ذینفع 2		
    public string BnfAddress2 { get; set; }

    //آدرس ذینفع 3		
    public string BnfAddress3 { get; set; }

    //آدرس ذینفع 4		
    public string BnfAddress4 { get; set; }

    //تلفن ذینفع			
    public string BnfTel { get; set; }

    //کد پستی ذینفع			
    public string BnfPostCode { get; set; }

    //فلگ نوع شماره قراگیر آورنده			
    public string BrgIdStat { get; set; }

    //شماره فراگیر آورنده				
    public string BrgId { get; set; }

    //نام آورنده					
    public string BrgName { get; set; }

    //نام خانوادگی آورنده					
    public string BrgFamily { get; set; }

    //آدرس آورنده ۱					
    public string BrgAddress1 { get; set; }

    //آدرس آورنده 2				
    public string BrgAddress2 { get; set; }

    //آدرس آورنده 3				
    public string BrgAddress3 { get; set; }

    //آدرس آورنده 4				
    public string BrgAddress4 { get; set; }

    //تلفن آورنده					
    public string BrgTel { get; set; }

    //کد پستی آورنده					
    public string BrgPostCode { get; set; }

    //فلگ ارسال اطلاعات ذینفع ( آورنده ) از تحویلداری						
    public string Stat { get; set; }

    //فلگ شاخص نقدی یا غیر نقدی						
    public string NaghdiStat { get; set; }

    //بابت					
    public string Babat { get; set; }

    //شاخص نادیده گرفتن حداقل مانده با ارزش						
    public string TransferMinbl { get; set; }

    //شاخص اخذ کارمزد شناور با ارزش						
    public string ChargePattern { get; set; }

    //مبلغ کارمزد							
    public string ChargeAmt { get; set; }

    //اطلاعات دلخواه
    public string SequenceNo { get; set; }
}
