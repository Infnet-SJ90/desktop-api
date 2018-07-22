using System;
using System.Collections.Generic;
using System.Text;

namespace SJ90.DesktopAPI.Domain.Interfaces
{
    public interface ISchedulingService
    {
        IEnumerable<Scheduling> GetAll();
        Scheduling GetById(long id);
        void Add(Scheduling scheduling);
        void Update(long id, Scheduling scheduling);
        void Delete(long id);
    }
}
