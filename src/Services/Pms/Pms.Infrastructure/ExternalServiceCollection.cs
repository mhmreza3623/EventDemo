using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pms.Application.Interfaces;
using Pms.Domain.Common.SettingModels;
using Pms.Domain.Interfaces;
using Pms.Infrastructure.Services.ExternalServices.AdanicKariz;

namespace Pms.Infrastructure
{
    public static class ExternalServiceServiceCollection
    {
        public static void AddPaymentProviderServices(this IServiceCollection services,
            IConfigurationManager configurationManager)
        {
            services.AddScoped<IKarizPaymentServiceProxy, KarizPaymentServiceProxy>();

            var karizSetting = new AdanicKarizServiceSetting();
            configurationManager.GetSection("AdanicKarizServiceSetting").Bind(karizSetting);
        }
    }
}
