using DoxFrame.Hub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DoxFrame.Hub.Infrastructure
{
    public static class StartupSetup
    {
        // Sqllite local file
        //public static void AddDbContext(this IServiceCollection services, string connectionString) =>
        //    services.AddDbContext<AppDbContext>(options =>
        //        options.UseSqlite(connectionString)); // will be created in web project root
        
        // Postgres Database 
        public static void AddDbContext(this IServiceCollection services, string connectionString) =>
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString)); // will be created in web project root

        

    }
}
