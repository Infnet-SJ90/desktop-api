using System;

namespace SJ90.DesktopAPI.Domain
{
    /// <summary>
    /// Classe responsável por representar uma abstração de recurso
    /// </summary>
    public class Resource : BaseEntity
    {

        public int Weight { get; set; }

        public string LicensePlate { get; set; }

        public long SchedulingId { get; set; }
        public Scheduling Scheduling { get; set; }

    }
}