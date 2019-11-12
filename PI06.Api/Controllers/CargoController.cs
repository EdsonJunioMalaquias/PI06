using Microsoft.AspNetCore.Mvc;
using PI06.Api.IServiceRepository;
using PI06.Models.Entity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PI06.Api.Controllers
{
    [Route("api/[controller]")]
    public class CargoController : Controller
    {
        private readonly ICargoService _service;
        public CargoController(ICargoService _service)
        {
            this._service = _service;

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAllProperties(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return Json(result);
        }
        [HttpGet]
        [ProducesResponseType(typeof(Cargo), 200)]
        public IActionResult Get()
        {
            var consultaAll = _service.GetAllDistinct();
            return Json(consultaAll);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Cargo entity)
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
        public async Task<IActionResult> Update([FromBody] Cargo entity)
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
