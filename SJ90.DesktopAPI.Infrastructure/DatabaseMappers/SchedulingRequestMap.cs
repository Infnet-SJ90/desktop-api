using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SJ90.DesktopAPI.Domain;

namespace SJ90.DesktopAPI.Infrastructure.DatabaseMappers
{
    public class SchedulingRequestMap
    {
        public SchedulingRequestMap(EntityTypeBuilder<SchedulingRequest> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Status).IsRequired();

            entityBuilder.HasOne(request => request.Scheduling)
                         .WithOne(scheduling => scheduling.Request)
                         .HasForeignKey<Scheduling>(request => request.SchedulingRequestId).IsRequired();
        }
    }
}
