using SJ90.DesktopAPI.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SJ90.DesktopAPI.Services.Interfaces
{
    public interface ICitizenService
    {
        IEnumerable<Citizen> GetAll();
        Task<Citizen> GetById(long id);
        void Add(Citizen citizen);
        void Update(long id, Citizen citizen);
        void Delete(long id);
    }
}
