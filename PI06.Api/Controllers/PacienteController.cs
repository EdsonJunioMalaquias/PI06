using Microsoft.AspNetCore.Mvc;
using PI06.Api.IServiceRepository;
using PI06.Models.Entity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PI06.Api.Controllers
{
    [Route("api/[controller]")]
    public class PacienteController : Controller
    {
        private readonly IPacienteService _service;

        public PacienteController(IPacienteService pacienteService)
        {
            _service = pacienteService;
        }
        [HttpGet("cpf/{cpf}")]
        public IActionResult GetByCpfAllProperties(string cpf)
        {
            var result = _service.GetByCPFIncludingProperties(cpf);
            if (result is null)
            {
                return StatusCode(404, "CPF Não encontrado!");
            }
            return Json(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Paciente), 200)]
        public IActionResult GetByIdIncludingAllProperties(int id)
        {
            var obj = _service.GetByIdIncludingProperties(id);
            return Json(obj);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Paciente), 200)]
        public IActionResult GetAllIncludingAllProperties()
        {
            var obj = _service.GetAllIncludingProperties();
            return Json(obj);
        }


        [HttpPost]
        public IActionResult Post([FromBody] Paciente entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }
            try
            {

                entity.DtInclusao = DateTime.Now;
                _service.AddOrUpdateAndCommitSync(entity);
                return StatusCode(200, entity);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message.FirstOrDefault());
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var obj = await _service.GetByIdAsync(id);
            if (obj == null)
            {
                return NotFound();
            }
            try
            {
                await _service.RemoveAsync(obj);
                return new NoContentResult();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Paciente entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }
            entity.DtAlteracao = DateTime.Now;
            await _service.UpdateAsync(entity);
            return new NoContentResult();
        }
    }
}