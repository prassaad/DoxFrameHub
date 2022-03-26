using DoxFrame.Hub.Core.AccountAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoxFrameHub.Infrastructure.Data.Config
{
    public class HubUserConfiguration : IEntityTypeConfiguration<HubUser>
    {
        public void Configure(EntityTypeBuilder<HubUser> builder)
        {

            builder.Property(t => t.Email)
                .IsRequired();

        }
    }
}
