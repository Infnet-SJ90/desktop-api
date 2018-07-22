using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SJ90.DesktopAPI.Domain;
using SJ90.DesktopAPI.Domain.Enums;
using SJ90.DesktopAPI.Domain.Interfaces;
using SJ90.DesktopAPI.Infrastructure;

namespace SJ90.DesktopAPI.API.Controllers
{
    /// <summary>
    /// Controller responsável por lidar com operações relacionadas a agendamentos
    /// </summary>
    [Route("v1/[controller]")]
    public class SchedulingController : Controller
    {
        private readonly ISchedulingService _schedulingService;
        private readonly IMapper _mapper;

        public SchedulingController(ISchedulingService schedulingService, IMapper mapper)
        {
            _schedulingService = schedulingService;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtém todos os agendamentos
        /// </summary>
        /// <returns>Todos os agendamentos cadastrados</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Scheduling> schedulings = _schedulingService.GetAll();

            if (schedulings == null)
            {
                return NotFound();
            }

            return Ok(schedulings);
        }

        /// <summary>
        /// Obtém agendamento por identificador
        /// </summary>
        /// <param name="id">identificador do agendamento</param>
        /// <returns>Agendamento com o identificador passado</returns>
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var scheduling = _schedulingService.GetById(id);

            if (scheduling == null)
            {
                return NotFound();
            }

            return Ok(scheduling);      
        }

        /// <summary>
        /// Adiciona um agendamento
        /// </summary>
        /// <param name="value">Agendamento a ser adicionado</param>
        [HttpPost]
        public IActionResult Post([FromBody]Scheduling scheduling)
        {
            _schedulingService.Add(scheduling);

            return Ok();
        }

        /// <summary>
        /// Atualiza um agendamento
        /// </summary>
        /// <param name="id">Identificador do agendamento</param>
        /// <param name="value">Informações a serem atualizadas</param>
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody]Scheduling scheduling)
        {
            _schedulingService.Update(id, scheduling);

            return Ok();
        }

        /// <summary>
        /// Deleta um agendamento
        /// </summary>
        /// <param name="id">Identificador do agendamento a ser deletado</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _schedulingService.Delete(id);

            return Ok();
        }
    }
}
