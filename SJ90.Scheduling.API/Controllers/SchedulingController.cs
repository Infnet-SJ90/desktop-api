using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SJ90.DesktopAPI.Domain;
using SJ90.DesktopAPI.Domain.Enums;

namespace SJ90.DesktopAPI.API.Controllers
{
    /// <summary>
    /// Controller responsável por lidar com operações relacionadas a agendamentos
    /// </summary>
    [Route("v1/[controller]")]
    public class SchedulingController : Controller
    {
        /// <summary>
        /// Obtém todos os agendamentos
        /// </summary>
        /// <returns>Todos os agendamentos cadastrados</returns>
        [HttpGet]
        public IEnumerable<Scheduling> GetAll()
        {
            return new Scheduling[]
            {
                new Scheduling
                {
                    Id = 1,
                    Day = DateTime.Today,
                    Hour = 15,
                    Status = SchedulingStatus.Approved
                },
                new Scheduling
                {
                    Id = 2,
                    Day = DateTime.Today.AddDays(1),
                    Hour = 11,
                    Status = SchedulingStatus.Rejected
                }
            };
        }

        /// <summary>
        /// Obtém agendamento por identificador
        /// </summary>
        /// <param name="id">identificador do agendamento</param>
        /// <returns>Agendamento com o identificador passado</returns>
        [HttpGet("{id}")]
        public Scheduling Get(int id)
        {
            return new Scheduling
            {
                Id = 2,
                Day = DateTime.Today.AddDays(1),
                Hour = 11,
                Status = SchedulingStatus.Rejected
            };
        }

        /// <summary>
        /// Adiciona um agendamento
        /// </summary>
        /// <param name="value">Agendamento a ser adicionado</param>
        [HttpPost]
        public void Post([FromBody]Scheduling value)
        {
        }

        /// <summary>
        /// Atualiza um agendamento
        /// </summary>
        /// <param name="id">Identificador do agendamento</param>
        /// <param name="value">Informações a serem atualizadas</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Scheduling value)
        {
        }

        /// <summary>
        /// Deleta um agendamento
        /// </summary>
        /// <param name="id">Identificador do agendamento a ser deletado</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
