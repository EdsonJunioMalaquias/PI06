using Microsoft.AspNetCore.Mvc;
using PI06.Data.Context;
using PI06.Models.Entity;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using PI06.Api.IServiceRepository;
using System.Threading.Tasks;
using PI06.Data.Models.Entity;
using System;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PI06.Api.Controllers
{
    [Route("api/[controller]")]
    public class ConsultaController : Controller
    {
        private readonly IConsultaService _consultaService;

        public ConsultaController(IConsultaService consultaService) {

            _consultaService = consultaService;

        }

        [HttpGet("{idPaciente}")]
        [ProducesResponseType(typeof(Consulta), 200)]
        public IActionResult Get(int idPaciente) {
            var consultaAll = _consultaService.GetAllIncludingProperties(idPaciente);

            return Json(consultaAll);

        }
        [HttpPost]
        public IActionResult Post([FromBody] Consulta consulta) {
            if(consulta == null) {
                return BadRequest();
            }
            try
            {
                _consultaService.AddAsync(consulta);
                return CreatedAtRoute("GetConsulta", new {id = consulta.Id },consulta);

            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                throw;
            }


        } 


    }
}
