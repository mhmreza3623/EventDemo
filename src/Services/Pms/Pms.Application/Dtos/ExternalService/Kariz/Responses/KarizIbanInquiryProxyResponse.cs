namespace Pms.Application.Dtos.ExternalService.Kariz.Responses;
public class KarizIbanInquiryProxyResponse
{
    public AdanicApiBaseResultDto Result { get; set; }
    /// <summary>
    /// شناسه شبای استعلام شده
    /// </summary>
    public string Iban { get; set; }
    /// <summary>
    ///  شماره حساب
    /// </summary>
    public string Account { get; set; }
    /// <summary>
    ///  وضعیت حساب
    /// </summary>
    public string AccountStatus { get; set; }
    /// <summary>
    /// شاخص نیاز/عدم نیاز به شناسه واریز
    /// </summary>
    public string PayIdNeeded { get; set; }
    /// <summary>
    /// شاخص صحت شناسه واریز
    /// </summary>
    public string PayIdValidity { get; set; }
    /// <summary>
    /// اطلاعات اضافه
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// نام 
    /// </summary>
    public string Firstname { get; set; }
    /// <summary>
    /// نام خانوادگی
    /// </summary>
    public string LastName { get; set; }
    /// <summary>
    /// کد خطا
    /// </summary>
    public string AlertCode { get; set; }
    /// <summary>
    /// شرح خطا
    /// </summary>
    public string MessageOut { get; set; }


}

