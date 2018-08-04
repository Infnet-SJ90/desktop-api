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
    public class SchedulingService : ISchedulingService
    {
        private readonly ISchedulingRepository _schedulingRepository;
        private readonly DatabaseContext _context;

        public SchedulingService(DatabaseContext context, ISchedulingRepository schedulingRepository)
        {
            _schedulingRepository = schedulingRepository;
            _context = context;
        }

        public void Add(Scheduling scheduling)
        {
            _schedulingRepository.Create(scheduling);
        }

        public void Delete(long id)
        {
            _schedulingRepository.Delete(id);
        }

        public IEnumerable<Scheduling> GetAll()
        {
            return _schedulingRepository.GetAll();
        }

        public async Task<Scheduling> GetById(long id)
        {
            return await _schedulingRepository.GetById(id);
        }

        public async void Update(long id, Scheduling scheduling)
        {
            await _schedulingRepository.Update(id, scheduling);
        }
    }
}
