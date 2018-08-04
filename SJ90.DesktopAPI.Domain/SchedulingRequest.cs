using SJ90.DesktopAPI.Domain.Enums;

namespace SJ90.DesktopAPI.Domain
{
    public class SchedulingRequest : BaseEntity
    {
        public SchedulingRequestStatus Status { get; set; }

        public Scheduling Scheduling { get; set; }
        public long SchedulingId { get; set; }
    }
}
