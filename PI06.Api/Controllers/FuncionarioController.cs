using System;
using Microsoft.AspNetCore.Mvc;
using PI06.Data.Context;
using PI06.Models.Entity;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using PI06.Api.IServiceRepository;
using System.Threading.Tasks;

namespace PI06.Api.Controllers
{

    [Route("api/[controller]")]
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioService _service;
        
        public FuncionarioController(IFuncionarioService funcionarioService)
        {
            _service = funcionarioService;
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdIncludingAllProperties(int id)
        {
            var obj = _service.GetByIdIncludingProperties(id);
            return Json(obj);
        }

        [HttpGet]
        public IActionResult GetAllIncludingAllProperties()
        {
            var obj = _service.GetAllIncludingProperties();
            return Json(obj);
        }
        [HttpGet("{cargo}")]
        public IActionResult GetAllIncludingAllProperties(string cargo)
        {
            var obj = _service.GetAllIncludingProperties(cargo);
            return Json(obj);
        }
        [HttpGet("cpf/{cpf}")]
        public IActionResult GetByCpfAllProperties(string cpf)
        {
            var result = _service.GetByCpfIncludingProperties(cpf);
            if (result is null)
            {
                return StatusCode(404, "CPF Não encontrado!");
            }
            return Json(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Funcionario entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }

            try
            {
             
                await _service.AddAsync(entity);
                return StatusCode(200, entity);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
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
        public async Task<IActionResult> Update([FromBody] Funcionario entity)
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