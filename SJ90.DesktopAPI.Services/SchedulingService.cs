using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SJ90.DesktopAPI.Domain;
using SJ90.DesktopAPI.Infrastructure;
using SJ90.DesktopAPI.Infrastructure.Repositories.Interfaces;
using SJ90.DesktopAPI.Services.Common;
using SJ90.DesktopAPI.Services.Interfaces;
using SJ90.DesktopAPI.Services.Validation;
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

        public ServiceResult Add(Scheduling scheduling)
        {
            var result = new ServiceResult();
            var validationResult = new SchedulingValidator().Validate(scheduling);
            if (!validationResult.IsValid)
            {
                result.IsSuccess = false;
                result.Errors = validationResult.Errors;

                return result;
            }

            _schedulingRepository.Create(scheduling);

            result.IsSuccess = true;
            return result;
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
