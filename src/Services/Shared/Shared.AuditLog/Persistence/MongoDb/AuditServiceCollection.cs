using DataModels.Core.MongoDb;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Shared.AuditLog.Persistence.MongoDb.Repositories;

namespace Shared.AuditLog.Persistence.MongoDb
{
    public static class AuditServiceCollection
    {
        public static void AddAuditConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var value = configuration.GetSection(MongodbConfig.SectionName);
            services.Configure<MongodbConfig>(value);

            services.AddTransient<IAuditRepository, AuditRepository>();
        }
    }
}
