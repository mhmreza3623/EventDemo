using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pms.Domain.Constants;
using Pms.Domain.Entities;

namespace Pms.Infrastructure.Persistence.EF.EntitiesConfigurations.Payment
{
    public class PaymentDetailConfiguration : IEntityTypeConfiguration<PaymentDetail>
    {
        public void Configure(EntityTypeBuilder<PaymentDetail> builder)
        {
            builder.ToTable(PaymentStatics.TransactionDetailsTableName, PaymentStatics.SchemaName);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Response).IsRequired();

            builder.HasOne(x => x.Payment)
                .WithMany(q => q.PaymentDetails)
                .OnDelete(DeleteBehavior.NoAction);


            builder.Ignore(c => c.Events);

        }
    }
}
