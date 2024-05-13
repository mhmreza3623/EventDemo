using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pms.Domain.Entities;
using static Pms.Infrastructure.Persistence.EF.PaymentDbContextSchema;

namespace Pms.Infrastructure.Persistence.EF.EntitiesConfiguration
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable(PaymentStatics.TransactionTableName, PaymentStatics.SchemaName);

            builder.HasKey(x => x.Id);
            builder.Property(q => q.Status).IsRequired();
            builder.Property(q => q.Type).IsRequired();
            builder.Property(q => q.Amount).IsRequired().HasPrecision(18, 4); ;
            builder.Property(q => q.ReferenceId).IsRequired();
            builder.Property(q => q.ClientId).IsRequired();
            builder.Property(q => q.ClientName).IsRequired();
            builder.Property(q => q.ClientToken).IsRequired();
            builder.Property(q => q.ClientIp).IsRequired();
            builder.Property(q => q.Source).HasMaxLength(500);
            builder.Property(q => q.Destination).HasMaxLength(500);
            builder.Property(q => q.MetaData).HasMaxLength(1024);

            builder
                .HasIndex(q => new { q.ClientId, q.ReferenceId })
                .IsUnique()
                .HasDatabaseName("Ix_ClientReference");

        }
    }
}
