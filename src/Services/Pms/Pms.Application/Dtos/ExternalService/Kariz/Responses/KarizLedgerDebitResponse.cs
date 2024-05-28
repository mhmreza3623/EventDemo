namespace Pms.Application.Dtos.ExternalService.Kariz.Responses;

public class KarizLedgerDebitResponse
{
    public AdanicApiBaseResultDto Result { get; set; }

    //کد حساب دفتر کل
    public string LedgerCode { get; set; }

    //توضیحات
    public string Description { get; set; }

    //کلید مبدا برای معکوس کردن انتقال استفاده شده است
    public string OriginKey { get; set; }
    public string AlertCode { get; set; }
    public string MessageOut { get; set; }
}
