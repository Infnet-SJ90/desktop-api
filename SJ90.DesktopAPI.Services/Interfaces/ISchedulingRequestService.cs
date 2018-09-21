using SJ90.DesktopAPI.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SJ90.DesktopAPI.Services.Interfaces
{
    public interface ISchedulingRequestService
    {
        IEnumerable<SchedulingRequest> GetAll();
        Task<SchedulingRequest> GetById(long id);
        void Add(SchedulingRequest schedulingRequest);
        void Update(long id, SchedulingRequest schedulingRequest);
        void Delete(long id);
    }
}
