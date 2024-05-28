    namespace Pms.Application.Dtos.Api.Clients
{
    public class RegisterClientUserRequest
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public bool IsActive { get; set; }
        public string ClientUxId { get; set; }
    }
}
