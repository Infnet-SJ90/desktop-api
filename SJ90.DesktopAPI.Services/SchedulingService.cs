using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SJ90.DesktopAPI.Domain;
using SJ90.DesktopAPI.Domain.Interfaces;
using SJ90.DesktopAPI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SJ90.DesktopAPI.Services
{
    public class SchedulingService : ISchedulingService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public SchedulingService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(Scheduling scheduling)
        {
            _context.Add(scheduling);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var entity = _context.Set<Scheduling>().FirstOrDefault(scheduling => scheduling.Id == id);
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public IEnumerable<Scheduling> GetAll()
        {
            return _context.Set<Scheduling>().ToList();
        }

        public Scheduling GetById(long id)
        {
            return _mapper.Map<Scheduling>(_context.Set<Scheduling>().FirstOrDefault(scheduling => scheduling.Id == id));
        }

        public void Update(long id, Scheduling scheduling)
        {
            var entity = _context.Set<Scheduling>().FirstOrDefault(sc=> sc.Id == id);
            if (entity != null)
            {
                entity.Day = scheduling.Day;
                entity.Hour = scheduling.Hour;
                entity.Status = scheduling.Status;
                _context.Set<Scheduling>().Update(entity);
                _context.SaveChanges();
            }
        }
    }
}
