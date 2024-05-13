using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pms.Domain.Entities;
using static Pms.Infrastructure.Persistence.EF.PaymentDbContextSchema;

namespace Pms.Infrastructure.Persistence.EF.EntitiesConfiguration
{
    public class TransactionDetailConfiguration : IEntityTypeConfiguration<TransactionDetail>
    {
        public void Configure(EntityTypeBuilder<TransactionDetail> builder)
        {
            builder.ToTable(PaymentStatics.TransactionDetailsTableName, PaymentStatics.SchemaName);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Operation).IsRequired();
            builder.Property(x => x.Response).IsRequired();

            builder.HasOne(x => x.Transaction)
                .WithMany(q => q.TransactionDetails)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
