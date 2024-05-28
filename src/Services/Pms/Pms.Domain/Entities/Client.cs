using Core.EventBus.Events;
using Pms.Domain.Events;
using SharedKernel.Common.SqlModels;

namespace Pms.Domain.Entities
{
    public class Client : BaseEntity
    {
        internal Client() { }

        public string Name { get; private set; }
        public string DisplayName { get; private set; }
        public string? Ips { get; private set; }
        public bool IsActive { get; private set; }
        public string DpkUserName { get; private set; }
        public string DpkPassword { get; private set; }

        /// <summary>
        /// اطلاعاتی به ازای هر سامانه است که از بانک دریافت میشود 
        /// </summary>
        public string? ProviderUsername { get; private set; }
        public string? ProviderPassword { get; private set; }

        public List<ApplicationUser> Users { get; private set; }


        public static Client CreateClient(string name, string displayName, bool isActive, string dpkUsername,
            string dpkPassword, string providerUsername, string providerPassword, string? ips)
        {
            var client = new Client()
            {
                Name = name,
                ProviderPassword = providerPassword,
                IsActive = isActive,
                DisplayName = displayName,
                DpkPassword = dpkPassword,
                DpkUserName = dpkUsername,
                ProviderUsername = providerUsername,
                Ips = ips,
                UxId = Guid.NewGuid(),
            };
            client.Events.Add(new CreatedClientEvent(client.Name, client.UxId.ToString()));
            return client;
        }

        public Client UpdateClientDpkCredential(string uerName, string password)
        {
            this.DpkPassword = password;
            this.DpkUserName = uerName;

            this.Events.Add(new UpdateDpkCredentialClientEvent(this.UxId.ToString(), uerName));
            return this;
        }

        public Client UpdateClientProviderCredential(string username, string password)
        {
            this.DpkPassword = password;
            this.DpkUserName = username;
            this.Events.Add(new UpdateProviderCredentialClientEvent(this.UxId.ToString(), username));

            return this;
        }

    }
}
