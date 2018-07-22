using Microsoft.EntityFrameworkCore;
using SJ90.DesktopAPI.Domain;
using SJ90.DesktopAPI.Infrastructure.DatabaseMappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SJ90.DesktopAPI.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new SchedulingMap(modelBuilder.Entity<SchedulingEntity>());
        }
    }
}
