using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Common.MongoDb;

namespace SharedKernel.Logging.AuditLog
{
    public static class AuditServiceCollection
    {
        public static void AddAuditConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var value = configuration.GetSection(MongodbConfig.SectionName);
            services.Configure<MongodbConfig>(value);

        }
    }
}
