using Identity.Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Common.Constants;

namespace Identity.Infrastructure.Persistence
{
    public static class MsSqlServiceCollection
    {
        public static void AddDbContextConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString(DataBaseConstantKeys.DefaultSqlConnectionKey));
            });
        }
    }
}
