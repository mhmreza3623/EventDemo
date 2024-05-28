using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pms.Domain.Entities;

namespace Pms.Infrastructure.Persistence.EF.EntitiesConfigurations.Payment
{
    public class ApplicationUserConfiguration: IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasOne(q => q.Client)
                .WithMany(q => q.Users)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
