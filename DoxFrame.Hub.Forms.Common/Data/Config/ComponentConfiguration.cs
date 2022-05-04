using DoxFrame.Hub.Core.ProjectAggregate;
using DoxFrame.Hub.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoxFrameHub.Infrastructure.Data.Config
{
    public class ComponentConfiguration : IEntityTypeConfiguration<Component>
    {
        public void Configure(EntityTypeBuilder<Component> builder)
        {
            builder.Property(t => t.Title)
                .IsRequired();
            builder.Property(t => t.ComponentType)
               .IsRequired();
        }
    }
}
