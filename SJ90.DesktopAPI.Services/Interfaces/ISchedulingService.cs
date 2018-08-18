using SJ90.DesktopAPI.Domain;
using SJ90.DesktopAPI.Services.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SJ90.DesktopAPI.Services.Interfaces
{
    public interface ISchedulingService
    {
        IEnumerable<Scheduling> GetAll();
        Task<Scheduling> GetById(long id);
        ServiceResult Add(Scheduling scheduling);
        void Update(long id, Scheduling scheduling);
        void Delete(long id);
    }
}
