using DoxFrame.Hub.Core.AccountAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoxFrameHub.Infrastructure.Data.Config
{
    public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {

            builder.Property(t => t.DomainName)
                .IsRequired();

        }
    }
}
