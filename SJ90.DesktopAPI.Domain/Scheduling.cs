using SJ90.DesktopAPI.Domain.Enums;
using System;

namespace SJ90.DesktopAPI.Domain
{
    /// <summary>
    /// Classe responsável por representar uma abstração de agendamento
    /// </summary>
    public class Scheduling : BaseEntity
    {
        public DateTime Day { get; set; }

        public int Hour { get; set; }

        public SchedulingStatus Status { get; set; }


        public SchedulingRequest Request { get; set; }
        public long SchedulingRequestId { get; set; }
    }
}
