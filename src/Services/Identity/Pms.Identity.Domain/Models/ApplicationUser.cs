using Microsoft.AspNetCore.Identity;

namespace Identity.Domain.Models
{
    public class ApplicationUser : IdentityUser<long>
    {
        public ICollection<Client> Clients { get; set; }
    }
}
