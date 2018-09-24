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
    public class CitizenService : ICitizenService
    {
        private readonly ICitizenRepository _citizenRepository;
        private readonly DatabaseContext _context;

        public CitizenService(DatabaseContext context, ICitizenRepository citizenRepository)
        {
            _citizenRepository = citizenRepository;
            _context = context;
        }

        public void Add(Citizen citizen)
        {
            _citizenRepository.Create(citizen);
        }

        public void Delete(long id)
        {
            _citizenRepository.Delete(id);
        }

        public IEnumerable<Citizen> GetAll()
        {
            return _citizenRepository.GetAll();
        }

        public async Task<Citizen> GetById(long id)
        {
            return await _citizenRepository.GetById(id);
        }

        public async void Update(long id, Citizen citizen)
        {
            await _citizenRepository.Update(id, citizen);
        }
    }
}
