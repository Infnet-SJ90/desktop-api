using System;
using System.Collections.Generic;
using System.Text;

namespace SJ90.DesktopAPI.Domain.Enums
{
    /// <summary>
    /// Responsável por prover os estados disponíveis para os pedidos de agendamento
    /// </summary>
    public enum SchedulingRequestStatus
    {
        Pending = 1,
        Valid = 2,
        Invalid = 3,
        Cancelled = 4,
        Scheduled = 5,
        Concluded = 6
    }
}
