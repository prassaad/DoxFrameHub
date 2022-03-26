using DoxFrame.Hub.Core.ProjectAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoxFrameHub.Infrastructure.Data.Config
{
    public class ProcessConfiguration : IEntityTypeConfiguration<Process>
    {
        public void Configure(EntityTypeBuilder<Process> builder)
        {
            builder.Property(t => t.Title)
                .IsRequired();
            

        }
    }
}
