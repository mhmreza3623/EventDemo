using SharedKernel.Common.SqlModels;

namespace Identity.Domain.Models
{
    public class Client : BaseEntity
    {
        public Client()
        {
            UxId = Guid.NewGuid();
        }

        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Ips { get; set; }
        public bool IsActive { get; set; }
        public Guid UxId { get; set; }
    }
}
