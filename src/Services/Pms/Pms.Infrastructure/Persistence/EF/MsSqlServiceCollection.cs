using DataBase.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pms.Infrastructure.Persistence.EF.DbContexts;
using Pms.Infrastructure.Persistence.EF.Repositories;

namespace Pms.Infrastructure.Persistence.EF
{
    public static class MsSqlServiceCollection
    {
        public static void AddEFConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PaymentDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString(DataBaseConstantKeys.DefaultSqlConnectionKey));
            });

            services.AddTransient(typeof(IGeneralSqlRepository<>), typeof(GeneralSqlRepository<>));
        }
    }
}
