using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pms.Domain.Entities;

namespace Pms.Infrastructure.Persistence.EF.EntitiesConfigurations.Payment
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable(PaymentStatics.AccountTableName, PaymentStatics.SchemaName);

            builder.HasKey(x => x.Id);
            builder.Property(q => q.DisplayTitle).IsRequired().HasMaxLength(500);
            builder.Property(q => q.Title).HasMaxLength(500);
            builder.Property(q => q.Identifier).HasMaxLength(500);

            builder.HasOne(q => q.Client)
                .WithMany(q => q.Accounts)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(q => q.Identifier).HasDatabaseName("Ix_identifier");
        }
    }
}
