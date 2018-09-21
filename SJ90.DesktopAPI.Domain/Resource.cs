using SJ90.DesktopAPI.Domain.Enums;
using System;

namespace SJ90.DesktopAPI.Domain
{
    /// <summary>
    /// Classe responsável por representar uma abstração de recurso
    /// </summary>
    public class Resource : BaseEntity
    {

        public int Weight { get; set; }
        public int MaximumWeight { get; set; }

        public ResourceStatus status { get; set; }

        public ResourceType type{ get; set; }

        public long SchedulingId { get; set; }
        public Scheduling Scheduling { get; set; }

    }
}