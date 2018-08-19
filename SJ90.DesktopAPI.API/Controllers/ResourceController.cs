using Microsoft.AspNetCore.Mvc;
using SJ90.DesktopAPI.Domain;
using SJ90.DesktopAPI.Services.Interfaces;
using System.Collections.Generic;

namespace SJ90.DesktopAPI.API.Controllers
{
    /// <summary>
    /// Controller responsável por lidar com operações relacionadas a agendamentos
    /// </summary>
    [Route("v1/[controller]")]
    public class ResourceController : Controller
    {
        private readonly IResourceService _resourceService;

        public ResourceController(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        /// <summary>
        /// Obtém todos os agendamentos
        /// </summary>
        /// <returns>Todos os agendamentos cadastrados</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Resource> resources = _resourceService.GetAll();

            if (resources == null)
            {
                return NotFound();
            }

            return Ok(resources);
        }

        /// <summary>
        /// Obtém agendamento por identificador
        /// </summary>
        /// <param name="id">identificador do agendamento</param>
        /// <returns>Agendamento com o identificador passado</returns>
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var resource = _resourceService.GetById(id);

            if (resource == null)
            {
                return NotFound();
            }

            return Ok(resource);      
        }

        /// <summary>
        /// Adiciona um agendamento
        /// </summary>
        /// <param name="resource">Agendamento a ser adicionado</param>
        [HttpPost]
        public IActionResult Post([FromBody]Resource resource)
        {
            _resourceService.Add(resource);

            return Ok();
        }

        /// <summary>
        /// Atualiza um agendamento
        /// </summary>
        /// <param name="id">Identificador do agendamento</param>
        /// <param name="resource">Informações a serem atualizadas</param>
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody]Resource resource)
        {
            _resourceService.Update(id, resource);

            return Ok();
        }

        /// <summary>
        /// Deleta um agendamento
        /// </summary>
        /// <param name="id">Identificador do agendamento a ser deletado</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _resourceService.Delete(id);

            return Ok();
        }
    }
}
