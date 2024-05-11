using DataBase.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pms.Infrastructure.Persistence.EF;
using Pms.Infrastructure.Persistence.EF.Repositories;
using Pms.Infrastructure.Persistence.MongoDb.Repositories;

namespace Pms.Infrastructure.Persistence
{
    public static class PersistentServiceCollection
    {
        public static void AddPersistentConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PaymentDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("default"));
            });

            var config = new MongodbConfig();
            configuration.GetSection(MongodbConfig.SectionName).Bind(config);
            
            services.AddTransient(typeof(IGeneralSqlRepository<>), typeof(GeneralSqlSqlRepository<>));
            services.AddTransient(typeof(IGeneralMongoRepository<>), typeof(IGeneralMongoRepository<>));
        }
    }
}
