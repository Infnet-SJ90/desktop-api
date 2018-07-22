using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SJ90.Scheduling.API.Controllers
{
    [Route("v1/[controller]")]
    public class SchedulingController : Controller
    {
        /// <summary>
        /// Obtém todos os agendamentos
        /// </summary>
        /// <returns>Todos os agendamentos cadastrados</returns>
        [HttpGet]
        public IEnumerable<string> GetAll()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Obtém agendamento por identificador
        /// </summary>
        /// <param name="id">identificador do agendamento</param>
        /// <returns>Agendamento com o identificador passado</returns>
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// Adiciona um agendamento
        /// </summary>
        /// <param name="value">Agendamento a ser adicionado</param>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        /// <summary>
        /// Atualiza um agendamento
        /// </summary>
        /// <param name="id">Identificador do agendamento</param>
        /// <param name="value">Informações a serem atualizadas</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
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
