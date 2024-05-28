using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pms.Domain.Constants;

namespace Pms.Infrastructure.Persistence.EF.EntitiesConfigurations.Payment
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Domain.Entities.Payment>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Payment> builder)
        {
            builder.ToTable(PaymentStatics.TransactionTableName, PaymentStatics.SchemaName);

            builder.HasKey(x => x.Id);
            builder.Property(q => q.Status).IsRequired();
            builder.Property(q => q.Type).IsRequired();
            builder.Property(q => q.Amount).IsRequired().HasPrecision(18, 4); ;
            builder.Property(q => q.ReferenceId).IsRequired();
            builder.Property(q => q.RequestToken).IsRequired();
            builder.Property(q => q.Source).HasMaxLength(500);
            builder.Property(q => q.Destination).HasMaxLength(500);
            builder.Property(q => q.MetaData).HasMaxLength(1024);
            builder.Property(q => q.MetaData).HasMaxLength(1024);

            builder
                .HasIndex(q => new { q.ClientId, q.ReferenceId })
                .IsUnique()
                .HasDatabaseName("Ix_ClientReference");

            builder
                .HasIndex(q => new { q.RequestToken })
                .IsUnique()
                .HasDatabaseName("Ix_RequestToken");

            builder.Ignore(c => c.Events);


        }
    }
}
