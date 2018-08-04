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
    public class SchedulingRequestService : ISchedulingRequestService
    {
        private readonly ISchedulingRequestRepository _schedulingRequestRepository;
        private readonly DatabaseContext _context;

        public SchedulingRequestService(DatabaseContext context, ISchedulingRequestRepository schedulingRequestRepository)
        {
            _schedulingRequestRepository = schedulingRequestRepository;
            _context = context;
        }

        public void Add(SchedulingRequest schedulingRequest)
        {
            _schedulingRequestRepository.Create(schedulingRequest);
        }

        public void Delete(long id)
        {
            _schedulingRequestRepository.Delete(id);
        }

        public IEnumerable<SchedulingRequest> GetAll()
        {
            return _schedulingRequestRepository.GetAll();
        }

        public async Task<SchedulingRequest> GetById(long id)
        {
            return await _schedulingRequestRepository.GetById(id);
        }

        public async void Update(long id, SchedulingRequest schedulingRequest)
        {
            await _schedulingRequestRepository.Update(id, schedulingRequest);
        }
    }
}
