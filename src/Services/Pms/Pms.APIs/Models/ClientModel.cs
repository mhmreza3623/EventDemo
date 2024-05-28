namespace Pms.APIs.Models
{
    public class ClientModel
    {
        public bool IsActive { get; set; }
        public string ClientName { get; set; }
        public Guid ClientUxId { get; set; }
        public string DisplayName { get; set; }
        public long Id { get; set; }
    }
}
