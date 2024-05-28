namespace Pms.Application.Dtos.ExternalService.Kariz.Responses;

public class KarizAccountTransferResponse : KarizBaseResponse
{
    //نام مشتری بدهکار
    public string debtorName { get; set; }

    //نام خانوادگی مشتری بدهکار
    public string debtorFamilyName { get; set; }

    //نام مشتری بستانکار
    public string creditorName { get; set; }

    //نام خانوادگی مشتری بستانکار
    public string creditorFamilyName { get; set; }

    //یادداشت مسئولین 1
    public string officerComment1 { get; set; }

    //یادداشت مسئولین 2
    public string officerComment2 { get; set; }

    //یادداشت مسئولین 3
    public string officerComment3 { get; set; }

    //یادداشت مسئولین 4
    public string officerComment4 { get; set; }

    //یادداشت مسئولین 5
    public string officerComment5 { get; set; }

    //یادداشت مسئولین 6
    public string officerComment6 { get; set; }

    //شناسه‌ی تراکنش
    public string originKey { get; set; }

    //مبلغ کارمزد
    public string chargeAmount { get; set; }

    public string alertCode { get; set; }

    public string messageOut { get; set; }
}
