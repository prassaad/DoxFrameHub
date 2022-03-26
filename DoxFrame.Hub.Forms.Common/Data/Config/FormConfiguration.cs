using DoxFrame.Hub.Core.ProjectAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoxFrameHub.Infrastructure.Data.Config
{
    public class FormConfiguration : IEntityTypeConfiguration<Form>
    {
        public void Configure(EntityTypeBuilder<Form> builder)
        {
            builder.Property(t => t.Title)
                .IsRequired();
        }
    }
}
