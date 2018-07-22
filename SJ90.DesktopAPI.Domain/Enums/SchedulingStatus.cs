using System;
using System.Collections.Generic;
using System.Text;

namespace SJ90.DesktopAPI.Domain.Enums
{
    /// <summary>
    /// Responsável por prover os estados disponíveis para os agendamentos
    /// </summary>
    public enum SchedulingStatus
    {
        Solicited = 1,
        Approved = 2,
        Rejected = 3
    }
}
