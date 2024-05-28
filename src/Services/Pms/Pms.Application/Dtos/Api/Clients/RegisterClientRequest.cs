namespace Pms.Application.Dtos.Api.Clients
{
    public class RegisterClientRequest
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string DpkUsername { get; set; }
        public string DpkPassword { get; set; }
        public string Ips { get; set; }
        public string KarizUsername { get; set; }
        public string KarizPassword { get; set; }
    }
}
