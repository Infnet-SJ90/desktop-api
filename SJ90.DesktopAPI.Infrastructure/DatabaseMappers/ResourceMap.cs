using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SJ90.DesktopAPI.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SJ90.DesktopAPI.Infrastructure.DatabaseMappers
{
    class ResourceMap
    {
        public ResourceMap(EntityTypeBuilder<Resource> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Weight).IsRequired();
            entityBuilder.Property(t => t.LicensePlate).IsRequired();

            entityBuilder.HasOne(c => c.Scheduling)
                         .WithMany(e => e.Resource)
                         .HasForeignKey(c => c.SchedulingId);
        }
    }
}
