using Ardalis.EFCore.Extensions;
using DoxFrame.Hub.Core.AccountAggregate;
using DoxFrame.Hub.Core.ProjectAggregate;
using DoxFrame.Hub.SharedKernel;
using DoxFrameHub.SharedKernel;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DoxFrame.Hub.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        private readonly IMediator _mediator;


        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options, IMediator mediator)
            : base(options)
        {
            _mediator = mediator;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseNpgsql("User ID=jghthmyvlgrjuc;Password=a1700f502b3e5e52cac0318591381b038b3e426a6b805cce14d634326bd862ac;Server=ec2-23-21-4-7.compute-1.amazonaws.com;Port=5432;Database=dcf6feorrh3ua6;Integrated Security=true;Pooling=true;SSL Mode=Require;Trust Server Certificate=true");
            }
        }
 
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<HubUser> HubUsers { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Workflow> Workflows { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Component> Components { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // alternately this is built-in to EF Core 2.2
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // ignore events if no dispatcher provided
            if (_mediator == null) return result;

            // dispatch events only if save was successful
            var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach (var entity in entitiesWithEvents)
            {
                var events = entity.Events.ToArray();
                entity.Events.Clear();
                foreach (var domainEvent in events)
                {
                    await _mediator.Publish(domainEvent).ConfigureAwait(false);
                }
            }

            return result;
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}