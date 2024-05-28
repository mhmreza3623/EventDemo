using Microsoft.AspNetCore.Identity;

namespace Pms.Domain.Entities
{
    public class ApplicationUser : IdentityUser<long>
    {
        public ApplicationUser()
        {
            CreateTime = DateTime.Now;
            UxId = Guid.NewGuid();
        }

        public bool IsActive { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? ModifyTime { get; set; }
        public Guid UxId { get; set; }

        public Client Client { get; set; }
    }
}
