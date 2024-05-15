using DataModels.Core.MongoDb;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pms.Domain.Repositories;
using Pms.Infrastructure.Persistence.MongoDb.Repositories;

namespace Pms.Infrastructure.Persistence.MongoDb
{
    public static class MongoDbServiceCollection
    {
        public static void AddMongodbConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongodbConfig>(configuration.GetSection(MongodbConfig.SectionName));
            services.AddTransient(typeof(IGeneralMongoRepository<>), typeof(GeneralMongoRepository<>));
            services.AddTransient<ITransactionRepository, TransactionRepository>();
        }
    }
}
