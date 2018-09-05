using System;
using System.Collections.Generic;
using System.Text;

namespace SJ90.DesktopAPI.Domain
{
    /// <summary>
    /// Classe responsável por representar uma abstração de cidadão
    /// </summary>
    public class Citizen : BaseEntity
    {
        public string Name { get; set; }

        public string CPF { get; set; }
        public Scheduling scheduling { get; set; }
        public ICollection<Scheduling> Scheduling { get; set; }
    }
}
