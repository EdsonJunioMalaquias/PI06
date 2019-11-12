using Microsoft.AspNetCore.Mvc;
using PI06.Api.IServiceRepository;
using PI06.Data.Models.Entity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PI06.Api.Controllers
{
    [Route("api/[controller]")]
    public class FilaController : Controller
    {
        private readonly IFilaService _service;

        public FilaController(IFilaService filaService)
        {
            _service = filaService;
        }


        [HttpGet("{id}")]
        public IActionResult GetByIdIncludingAllProperties(int id)
        {
            var obj = _service.GetByFuncionarioIncludeAllProperity(id);
            return Json(obj);
        }

        [HttpGet]
        public IActionResult GetAllIncludingAllProperties()
        {
            var obj = _service.GetIncludeAllProperity();
            return Json(obj);
        }


        [HttpPost]
        public IActionResult Post([FromBody] Fila entity)
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
        public async Task<IActionResult> Update([FromBody] Fila entity)
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