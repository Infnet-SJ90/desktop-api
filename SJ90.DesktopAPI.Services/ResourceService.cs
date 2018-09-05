using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SJ90.DesktopAPI.Domain;
using SJ90.DesktopAPI.Infrastructure;
using SJ90.DesktopAPI.Infrastructure.Repositories.Interfaces;
using SJ90.DesktopAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SJ90.DesktopAPI.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IResourceRepository _resourceRepository;
        private readonly DatabaseContext _context;

        public ResourceService(DatabaseContext context, IResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
            _context = context;
        }

        public void Add(Resource resource)
        {
            _resourceRepository.Create(resource);
        }

        public void Delete(long id)
        {
            _resourceRepository.Delete(id);
        }

        public IEnumerable<Resource> GetAll()
        {
            return _resourceRepository.GetAll();
        }

        public async Task<Resource> GetById(long id)
        {
            return await _resourceRepository.GetById(id);
        }

        public async void Update(long id, Resource resource)
        {
            await _resourceRepository.Update(id, resource);
        }
    }
}
