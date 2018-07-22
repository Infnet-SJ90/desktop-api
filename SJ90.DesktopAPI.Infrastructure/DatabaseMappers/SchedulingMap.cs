using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SJ90.DesktopAPI.Infrastructure.DatabaseMappers
{
    public class SchedulingMap
    {
        public SchedulingMap(EntityTypeBuilder<SchedulingEntity> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Day).IsRequired();
            entityBuilder.Property(t => t.Hour).IsRequired();
            entityBuilder.Property(t => t.Status).IsRequired();
        }
    }
}
