using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pms.Domain.Interfaces;
using Pms.Infrastructure.Services.DomainServices;

namespace Pms.Application
{
    public static class DomainServicesCollection
    {
        public static void AddDomainServices(this IServiceCollection services, IConfigurationManager configurationManager)
        {
            services.AddTransient<IPaymentDomainService, PaymentDomainService>();
            services.AddTransient<IIdentityService, IdentityService>();

       
        }
    }
}
