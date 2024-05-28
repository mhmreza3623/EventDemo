namespace Pms.Application.Dtos.ExternalService.Kariz.Responses;

public class KarizAccountWithdrawResponse : KarizBaseResponse
{


    public string TranLink { get; set; }
    public string Date { get; set; }
    public string Time { get; set; }
    //نام
    public string CustomerName { get; set; }

    //نام خانوادگی
    public string CustomerFamilyName { get; set; }

    //مانده جاری
    public string CurrentBalance { get; set; }

    //مانده در دسترس
    public string AvailableBalance { get; set; }

    //مانده موثر
    public string EffectiveBalance { get; set; }

    //نام کوتاه
    public string ShortName { get; set; }

    //شرایط برداشت
    public string AccountConditions { get; set; }

    //یادداشت مسئولین
    public string[] OfficerComments { get; set; }


    public string OriginKey { get; set; }

    //هزینه تراکنش
    public string ChargeAmount { get; set; }

    //شاخص دفترچه
    public string PsbkFlag { get; set; }

    public string RespOfficer { get; set; }
    public string AlertCode { get; set; }


    public string MessageOut { get; set; }
}
