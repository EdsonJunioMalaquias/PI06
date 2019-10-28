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

namespace PI06.Api.Controllers
{
    [Route("api/[controller]")]
    public class ExameController : Controller
    {
        private readonly IExameService _service;
        public ExameController(IExameService _service)
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
        public async Task<IActionResult> Get()
        {
            var consultaAll = await _service.GetAllAsync();
            return Json(consultaAll);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Exame entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }
            try
            {
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
        public async Task<IActionResult> Update([FromBody] Exame entity)
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