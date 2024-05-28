using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pms.Domain.Entities;
using Pms.Infrastructure.Persistence.EF.EntitiesConfigurations.Payment;

namespace Pms.Infrastructure.Persistence.EF.DbContexts
{
    public class PaymentDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, long>
    {
        #region DbSets
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }
        public DbSet<Client> Clients { get; set; }

        #endregion


        public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(PaymentConfiguration).Assembly);
        }
    }
}
