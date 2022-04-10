using Ardalis.ListStartupServices;
using Auth0.AspNetCore.Authentication;
using Autofac;
using DoxFrame.Hub.Core;
using DoxFrame.Hub.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace DoxFrame.Hub.Web
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration config, IWebHostEnvironment env)
        {
            Configuration = config;
            _env = env;
        }

        public IConfiguration Configuration { get; }

       
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddRazorPages()
            .AddRazorRuntimeCompilation();

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //string connectionString = Configuration.GetConnectionString("SqliteConnection");  //Configuration.GetConnectionString("DefaultConnection");
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext(connectionString);

            services.AddControllersWithViews().AddNewtonsoftJson();
            services.AddRazorPages();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DoxFrame API", Version = "v1" });
                c.EnableAnnotations();
            });

            // add list services for diagnostic purposes - see https://github.com/ardalis/AspNetCoreStartupServices
            services.Configure<ServiceConfig>(config =>
            {
                config.Services = new List<ServiceDescriptor>(services);

                // optional - default path to view services is /listallservices - recommended to choose your own path
                config.Path = "/listservices";
            });

            //Auth0
            services
                .AddAuth0WebAppAuthentication(options =>
                {
                    options.Domain = Configuration["Auth0:Domain"];
                    options.ClientId = Configuration["Auth0:ClientId"];
                    options.ClientSecret = Configuration["Auth0:ClientSecret"];
                    options.Scope = "openid profile email metadata";
                    //options.Scope = "picture";

                }).WithAccessToken(options =>
                {
                    options.Audience = Configuration["Auth0:Audience"];
                });

            //Added for session state
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = System.TimeSpan.FromMinutes(10);
                options.Cookie.IsEssential = true;
            });

           

        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new DefaultCoreModule());
            builder.RegisterModule(new DefaultInfrastructureModule(_env.EnvironmentName == "Development"));
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.EnvironmentName == "Development")
            {
                app.UseDeveloperExceptionPage();
                app.UseShowAllServicesMiddleware();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseSession();
            app.UseRouting();
            app.UseCors();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)); // allow any origin
               // .AllowCredentials()); // allow credentials


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DoxFrame API V1"));


            app.UseAuthentication();
            app.UseAuthorization();
           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
                endpoints.MapAreaControllerRoute(
                          name: "App",
                          areaName: "App",
                          pattern: "App/{controller=Home}/{action=Index}/{id?}");
            });


            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapAreaControllerRoute(
            //        name: "Admin",
            //        areaName: "Admin",
            //        pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

            //    endpoints.MapAreaControllerRoute(
            //        name: "Forms",
            //        areaName: "Forms",
            //        pattern: "Forms/{controller=Home}/{action=Index}/{id?}");

            //    endpoints.MapAreaControllerRoute(
            //        name: "WorkFlows",
            //        areaName: "WorkFlows",
            //        pattern: "WorkFlows/{controller=Home}/{action=Index}/{id?}");

            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");
            //});
        }
    }
}
