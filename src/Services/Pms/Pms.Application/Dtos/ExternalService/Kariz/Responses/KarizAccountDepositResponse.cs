namespace Pms.Application.Dtos.ExternalService.Kariz.Responses;

public class KarizAccountDepositResponse : KarizBaseResponse
{
    public string CustomerName { get; set; }

    public string CustomerFamilyName { get; set; }

    // موجودی فعلی
    public string CurrentBalance { get; set; }

    //موجودی در دسترس
    public string AvailableBalance { get; set; }

    public string ShortName { get; set; }

    public string AccountConditions { get; set; }

    public string[] OfficerComments { get; set; }

    public string OriginKey { get; set; }

    public string ChargeAmount { get; set; }

    public string PsbkFlag { get; set; }

    public string AlertCode { get; set; }

    public string MessageOut { get; set; }
}
