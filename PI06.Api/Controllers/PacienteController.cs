using System;
using Microsoft.AspNetCore.Mvc;
using PI06.Data.Context;
using PI06.Models.Entity;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using PI06.Api.IServiceRepository;

namespace PI06.Api.Controllers
{
    [Route("api/[controller]")]
    public class PacienteController : Controller
    {
        private readonly IPacienteService _pacienteService;

        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpGet("{id}", Name = "GetPaciente")]
        [ProducesResponseType(typeof(Paciente), 200)]
        public IActionResult Get(int id)
        {
            var paciente = _pacienteService.GetByIdIncludingProperties(id);

            return Json(paciente);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Paciente), 200)]
        public IActionResult Get()
        {

            var paciente = _pacienteService.GetAllAsync();
            return Json(paciente);
        }
        [HttpGet("cpf")]
        public IActionResult GetByCpfAllProperties([FromBody] string cpf)
        {
            var result = _pacienteService.GetByCPFIncludingProperties(cpf);
            if(result is null)
            {
                return StatusCode(404, "CPF Não encontrado!");
            }
            return Json(result);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Paciente paciente)
        {

            if (paciente == null)
            {
                return BadRequest();
            }
            try
            {
                _pacienteService.AddAsync(paciente);
                return CreatedAtRoute("GetFuncionario", new { id = paciente.Id }, paciente);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Paciente paciente)
        {
            if (paciente == null || paciente.Id != id)
            {
                return BadRequest();
            }
            paciente.DtAlteracao = DateTime.Now;
            _pacienteService.UpdateAsync(paciente);

            return new NoContentResult();
        }





    }
    

}
