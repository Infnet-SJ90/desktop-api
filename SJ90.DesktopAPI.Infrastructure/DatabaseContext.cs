using Microsoft.EntityFrameworkCore;
using SJ90.DesktopAPI.Domain;
using SJ90.DesktopAPI.Infrastructure.DatabaseMappers;
using System;
using System.Linq;

namespace SJ90.DesktopAPI.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Scheduling> Scheduling {get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new SchedulingMap(modelBuilder.Entity<Scheduling>());
            new SchedulingRequestMap(modelBuilder.Entity<SchedulingRequest>());
            new ResourceMap(modelBuilder.Entity<Resource>());
        }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).AddedDate = DateTime.UtcNow;
                }

                ((BaseEntity)entity.Entity).ModifiedDate = DateTime.UtcNow;
            }
        }
    }
}
