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
        private readonly IFuncionarioService _funcionarioService;

        public FuncionarioController(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }
        [HttpGet("{id}", Name = "GetFuncionario")]
        public IActionResult GetByIdAllProperties(int id)
        {
            var result = _funcionarioService.GetByIdIncludingProperties(id);

            return Json(result);
        }
        [HttpGet("cpf")]
        public IActionResult GetByCpfAllProperties([FromBody] string cpf)
        {
            var result = _funcionarioService.GetByCpfIncludingProperties(cpf);
            if(result is null)
            {
                return StatusCode(404, "CPF Não encontrado!");
            }
            return Json(result);
        }
        [HttpGet]
        [ProducesResponseType(typeof(Funcionario), 200)]
        public IActionResult Get()
        {

            var result = _funcionarioService.GetAllIncludingProperties();

            return Json(result);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Funcionario funcionario)
        {

            if (funcionario == null)
            {
                return BadRequest();
            }
            try
            {
                _funcionarioService.AddAsync(funcionario);
                return CreatedAtRoute("GetFuncionario", new { id = funcionario.Id }, funcionario);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Funcionario funcionario)
        {
            if (funcionario == null || funcionario.Id != id)
            {
                return BadRequest();
            }
            funcionario.DtAlteracao = DateTime.Now;
            _funcionarioService.UpdateAsync(funcionario);

            return new NoContentResult();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var funcionario = _funcionarioService.GetByIdIncludingProperties(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            
            if (funcionario == null)
            {
                return BadRequest();
            }

            try
            {
                Cargo cargo = funcionario.Cargo;
                Conselho conselho = funcionario.Conselho;
                Pessoa pessoa = funcionario.Pessoa;
                _funcionarioService.RemoveAsync(cargo);
                _funcionarioService.RemoveAsync(conselho);
                _funcionarioService.RemoveAsync(funcionario);
                _funcionarioService.RemoveAsync(pessoa);
                

                return new NoContentResult();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }







    }
}