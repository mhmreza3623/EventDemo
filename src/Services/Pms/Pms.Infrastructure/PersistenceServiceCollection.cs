using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Pms.Application.Queries;
using Pms.Domain.Entities;
using Pms.Domain.Interfaces;
using Pms.Domain.Repositories;
using Pms.Infrastructure.Persistence;
using Pms.Infrastructure.Persistence.EF.DbContexts;
using Pms.Infrastructure.Persistence.EF.Repositories;
using Pms.Infrastructure.Persistence.MongoDb.Repositories;
using SharedKernel.Common.Constants;
using SharedKernel.Common.MongoDb;

namespace Pms.Infrastructure
{
    public static class PersistenceServiceCollection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            MongoDependency(services, configuration);


            SqlDependency(services, configuration);
        }

        private static void SqlDependency(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PaymentDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString(DataBaseConstantKeys.DefaultSqlConnectionKey));
            });

            services.AddTransient(typeof(IGeneralSqlRepository<>), typeof(BaseEntityRepository<>));
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IDomainEventHandlingExecutor, DomainEventHandlingExecutor>();
            services.AddIdentity<ApplicationUser, ApplicationRole>(setupAction =>
                {
                    setupAction.Password.RequireDigit = true;
                    setupAction.Password.RequiredUniqueChars = 0;
                    setupAction.Password.RequireLowercase = false;
                    setupAction.Password.RequireNonAlphanumeric = false;
                    setupAction.Password.RequireUppercase = false;
                    setupAction.Password.RequiredLength = 3;
                    setupAction.SignIn.RequireConfirmedEmail = false;
                    setupAction.SignIn.RequireConfirmedPhoneNumber = false;
                })
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<PaymentDbContext>();



        }

        private static void MongoDependency(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongodbConfig>(configuration.GetSection(MongodbConfig.SectionName));
            services.AddTransient(typeof(IGeneralMongoRepository<>), typeof(GeneralMongoRepository<>));
            services.AddTransient<IAuditRepository, AuditRepository>();
            services.AddTransient<IEventLogRepository, EventLogRepository>();
        }
    }
}
