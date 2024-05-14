using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pms.Domain.Entities;
using Pms.Infrastructure.Persistence.EF.EntitiesConfigurations.Payment;

namespace Pms.Infrastructure.Persistence.EF.DbContexts
{
    public class PaymentDbContext : IdentityDbContext
    {
        #region DbSets
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionDetail> TransactionDetails { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }

        #endregion


        public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(TransactionConfiguration).Assembly);
        }
    }
}
