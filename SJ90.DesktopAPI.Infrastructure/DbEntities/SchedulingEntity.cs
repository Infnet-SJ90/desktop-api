using SJ90.DesktopAPI.Domain.Enums;
using SJ90.DesktopAPI.Infrastructure;
using System;

namespace SJ90.DesktopAPI.Infrastructure
{
    /// <summary>
    /// Entidade agendamento
    /// </summary>
    public class SchedulingEntity : BaseEntity
    {
        public DateTime Day { get; set; }

        public int Hour { get; set; }

        public SchedulingStatus Status { get; set; }
    }
}
