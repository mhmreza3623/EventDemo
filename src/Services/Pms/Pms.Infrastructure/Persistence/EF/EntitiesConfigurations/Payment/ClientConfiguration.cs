using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pms.Domain.Entities;

namespace Pms.Infrastructure.Persistence.EF.EntitiesConfigurations.Payment
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
