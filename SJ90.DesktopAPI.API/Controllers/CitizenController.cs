using Microsoft.AspNetCore.Mvc;
using SJ90.DesktopAPI.Domain;
using SJ90.DesktopAPI.Services.Interfaces;
using System.Collections.Generic;

namespace SJ90.DesktopAPI.API.Controllers
{
    /// <summary>
    /// Controller responsável por lidar com operações relacionadas a cidadãos
    /// </summary>
    [Route("v1/[controller]")]
    public class CitizenController : Controller
    {
        private readonly ICitizenService _citizenService;

        public CitizenController(ICitizenService citizenService)
        {
            _citizenService = citizenService;
        }

        /// <summary>
        /// Obtém todos os cidadãos
        /// </summary>
        /// <returns>Todos os cidadãos cadastrados</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Citizen> citizens = _citizenService.GetAll();

            if (citizens == null)
            {
                return NotFound();
            }

            return Ok(citizens);
        }

        /// <summary>
        /// Obtém cidadão por identificador
        /// </summary>
        /// <param name="id">identificador do cidadão</param>
        /// <returns>Agendamento com o identificador passado</returns>
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var citizen = _citizenService.GetById(id);

            if (citizen == null)
            {
                return NotFound();
            }

            return Ok(citizen);      
        }

        /// <summary>
        /// Adiciona um cidadão
        /// </summary>
        /// <param name="citizen">cidadão a ser adicionado</param>
        [HttpPost]
        public IActionResult Post([FromBody]Citizen citizen)
        {
            _citizenService.Add(citizen);

            return Ok();
        }

        /// <summary>
        /// Atualiza um cidadão
        /// </summary>
        /// <param name="id">Identificador do cidadão</param>
        /// <param name="citizen">Informações a serem atualizadas</param>
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody]Citizen citizen)
        {
            _citizenService.Update(id, citizen);

            return Ok();
        }

        /// <summary>
        /// Deleta um cidadão
        /// </summary>
        /// <param name="id">Identificador do cidadão a ser deletado</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _citizenService.Delete(id);

            return Ok();
        }
    }
}
