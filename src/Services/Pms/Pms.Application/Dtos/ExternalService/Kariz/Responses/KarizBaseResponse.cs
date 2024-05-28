namespace Pms.Application.Dtos.ExternalService.Kariz.Responses;

public class KarizBaseResponse
{
    public AdanicApiBaseResultDto Result { get; set; }

    public string CicsTransId { get; set; }

    public string SeqNo { get; set; }

    public string DataType { get; set; }

    public string Acknowledge { get; set; }

    public string Msgnbr { get; set; }
}

public class AdanicApiBaseResultDto
{
    public int Code { get; set; }

    public string KarizMessage { get; set; }

    public string Message { get; set; }

    public string ReferenceId { get; set; }

    public string Timestamp { get; set; }

}