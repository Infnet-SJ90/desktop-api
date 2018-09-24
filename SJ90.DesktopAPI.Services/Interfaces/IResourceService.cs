using SJ90.DesktopAPI.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SJ90.DesktopAPI.Services.Interfaces
{
    public interface IResourceService
    {
        IEnumerable<Resource> GetAll();
        Task<Resource> GetById(long id);
        void Add(Resource resource);
        void Update(long id, Resource resource);
        void Delete(long id);
    }
}
