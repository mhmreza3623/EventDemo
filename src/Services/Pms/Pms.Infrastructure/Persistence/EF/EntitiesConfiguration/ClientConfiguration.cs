using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pms.Domain.Entities;
using static Pms.Infrastructure.Persistence.EF.PaymentDbContextSchema;

namespace Pms.Infrastructure.Persistence.EF.EntitiesConfiguration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable(PaymentStatics.ClientTableName, PaymentStatics.SchemaName);

            builder.HasKey(x => x.Id);
            builder.Property(q => q.DisplayName).IsRequired().HasMaxLength(500);
            builder.Property(q => q.Ips).HasMaxLength(256);
            builder.Property(q => q.Name).IsRequired().HasMaxLength(256);

        }
    }
}
