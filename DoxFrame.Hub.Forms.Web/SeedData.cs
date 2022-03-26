using DoxFrame.Hub.Core.ProjectAggregate;
using DoxFrame.Hub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace DoxFrame.Hub.Web
{
    public static class SeedData
    {
        public static readonly Project SampleProject1 = new Project("Sample Project","Sample Summary");
        public static readonly Form form1 = new Form
        {
            Title = "Simple Form",
            Description = "Try to get the simple to build."
        };
        public static readonly Form form2 = new Form
        {
            Title = "Complex Form",
            Description = "Review the different projects in the solution and how they relate to one another."
        };
        

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var dbContext = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
            {
                // Look for any Form items.
                if (dbContext.Forms.Any())
                {
                    return;   // DB has been seeded
                }

                PopulateSampleData(dbContext);


            }
        }
        public static void PopulateSampleData(AppDbContext dbContext)
        {
            foreach (var item in dbContext.Forms)
            {
                dbContext.Remove(item);
            }
            dbContext.SaveChanges();

            SampleProject1.AddForm(form1);
            SampleProject1.AddForm(form2);
            dbContext.Projects.Add(SampleProject1);

            dbContext.SaveChanges();
        }
    }
}
