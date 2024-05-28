using SharedKernel.Common.SqlModels;

namespace Pms.Domain.Entities
{
    public class Client : BaseEntity
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string? Ips { get; set; }
        public bool IsActive { get; set; }
        public string DpkUserName { get; set; }
        public string DpkPassword { get; set; }

        /// <summary>
        /// اطلاعاتی به ازای هر سامانه است که از بانک دریافت میشود 
        /// </summary>
        public string? ProviderUsername { get; set; }
        public string? ProviderPassword { get; set; }

        public List<ApplicationUser> Users { get; set; }

    }
}
