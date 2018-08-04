using Microsoft.AspNetCore.Mvc;
using SJ90.DesktopAPI.Domain;
using SJ90.DesktopAPI.Services.Interfaces;
using System.Collections.Generic;

namespace SJ90.DesktopAPI.API.Controllers
{
    /// <summary>
    /// Controller responsável por lidar com operações relacionadas a pedidos de agendamentos
    /// </summary>
    [Route("v1/[controller]")]
    public class SchedulingRequestController : Controller
    {
        private readonly ISchedulingRequestService _schedulingRequestService;

        public SchedulingRequestController(ISchedulingRequestService schedulingService)
        {
            _schedulingRequestService = schedulingService;
        }

        /// <summary>
        /// Obtém todos os pedidos de agendamento
        /// </summary>
        /// <returns>Todos os pedidos de agendamento cadastrados</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<SchedulingRequest> schedulingRequests = _schedulingRequestService.GetAll();

            if (schedulingRequests == null)
            {
                return NotFound();
            }

            return Ok(schedulingRequests);
        }

        /// <summary>
        /// Obtém agendamento por identificador
        /// </summary>
        /// <param name="id">identificador do agendamento</param>
        /// <returns>Pedido de agendamento com o identificador passado</returns>
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var schedulingRequest = _schedulingRequestService.GetById(id);

            if (schedulingRequest == null)
            {
                return NotFound();
            }

            return Ok(schedulingRequest);      
        }

        /// <summary>
        /// Adiciona um pedido de agendamento
        /// </summary>
        /// <param name="schedulingRequest">Pedido a ser adicionado</param>
        [HttpPost]
        public IActionResult Post([FromBody]SchedulingRequest schedulingRequest)
        {
            _schedulingRequestService.Add(schedulingRequest);

            return Ok();
        }

        /// <summary>
        /// Atualiza um pedido de agendamento
        /// </summary>
        /// <param name="id">Identificador do pedido</param>
        /// <param name="schedulingRequest">Informações a serem atualizadas</param>
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody]SchedulingRequest schedulingRequest)
        {
            _schedulingRequestService.Update(id, schedulingRequest);

            return Ok();
        }

        /// <summary>
        /// Deleta um agendamento
        /// </summary>
        /// <param name="id">Identificador do agendamento a ser deletado</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _schedulingRequestService.Delete(id);

            return Ok();
        }
    }
}
