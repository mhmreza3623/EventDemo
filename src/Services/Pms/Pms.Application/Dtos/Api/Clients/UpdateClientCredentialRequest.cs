namespace Pms.Application.Dtos.Api.Clients;

public class UpdateClientCredentialRequest
{
    public string ClientUxId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

}