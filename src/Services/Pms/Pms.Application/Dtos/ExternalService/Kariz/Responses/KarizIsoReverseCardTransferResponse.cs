namespace Pms.Application.Dtos.ExternalService.Kariz.Responses;
public class KarizIsoReverseCardTransferResponse : KarizBaseResponse
{
    public string Uuid { get; set; }
    public string Stan { get; set; }
    public string RetrievalReferenceNumber { get; set; }
    public string TransactionLocalDate { get; set; }
}

