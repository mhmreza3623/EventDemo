using MediatR;

namespace Pms.Application.Commands.Client.RegisterClient
{
    public class RegisterClientCommand : IRequest<RegisterClientCommandResponse>
    {
        public string Name { get; }
        public string DisplayName { get; }
        public string DpkUserName { get; }
        public string DpkPassword { get; }
        public string? Ips { get; }
        public string ProviderUsename { get; }
        public string ProviderPassword { get; }

        public RegisterClientCommand(string name, string displayName, string dpkUserName, string dpkPassword, string? ips, string providerUsename, string providerPassword)
        {
            Name = name;
            DisplayName = displayName;
            DpkUserName = dpkUserName;
            DpkPassword = dpkPassword;
            Ips = ips;
            ProviderUsename = providerUsename;
            ProviderPassword = providerPassword;
        }
    }
}
