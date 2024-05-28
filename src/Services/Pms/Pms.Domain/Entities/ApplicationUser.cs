using Microsoft.AspNetCore.Identity;

namespace Pms.Domain.Entities
{
    public class ApplicationUser : IdentityUser<long>
    {
        internal ApplicationUser()
        {
            CreateTime = DateTime.Now;
            UxId = Guid.NewGuid();
        }

        public bool IsActive { get; private set; }
        public DateTime CreateTime { get; private set; }
        public DateTime? ModifyTime { get; private set; }
        public Guid UxId { get; private set; }
        public Client? Client { get; private set; }

        public static ApplicationUser CreateClientUser(string username, string password,bool isActive,Client client)
        {
            var user = new ApplicationUser()
            {
                UxId = Guid.NewGuid(),
                UserName = username,
                IsActive = isActive,
                Client = client
            };
            return user;


        }

        public static ApplicationUser Create(string username, string password, bool isActive)
        {
            var user = new ApplicationUser()
            {
                UxId = Guid.NewGuid(),
                UserName = username,
                IsActive = isActive,
            };
            return user;


        }


    }
}
