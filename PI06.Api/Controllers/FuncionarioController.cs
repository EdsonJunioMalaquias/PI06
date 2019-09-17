using System;
using Microsoft.AspNetCore.Mvc;
using PI06.Data.Context;
using PI06.Models.Entity;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PI06.Api.Controllers
{

    [Route("api/[controller]")]
    public class FuncionarioController : Controller
    {
        private readonly Contexto contexto;

        public FuncionarioController(Contexto contexto)
        {
            this.contexto = contexto;
        }
        [HttpGet("{id}", Name = "GetFuncionario")]
        [ProducesResponseType(typeof(Funcionario), 200)]
        public IActionResult Get(int id)
        {
            var funcionario = contexto.Funcionario.FirstOrDefault(x => x.Id == id);
            if (funcionario == null) {
                return NotFound();
            }
            contexto.Pessoa.FirstOrDefault(x => x.Id == id);
            contexto.Cargo.FirstOrDefault(x => x.Id == funcionario.IdCargo);
            contexto.Usuario.FirstOrDefault(x => x.Id == id);
            contexto.Conselho.FirstOrDefault(x => x.Id == id);

            return Json(funcionario);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Funcionario), 200)]
        public IActionResult Get()
        {

            var funcionario = contexto.Funcionario.ToList();
            if (funcionario == null)
            {
                return NotFound();
            }
            foreach (var item in funcionario)
            {
                item.Cargo = contexto.Cargo.FirstOrDefault(x => x.Id == item.IdCargo);
                item.Conselho = contexto.Conselho.FirstOrDefault(x => x.Id == item.Id);
                item.Usuario = contexto.Usuario.FirstOrDefault(x => x.Id == item.Id);
                item.Pessoa = contexto.Pessoa.FirstOrDefault(x => x.Id == item.Id);
            }
            return Json(funcionario);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Funcionario funcionario) {

            if (funcionario == null) {
                return BadRequest();
            }
            funcionario.DtInclusao = DateTime.Now;
            contexto.Set<Funcionario>().Add(funcionario);
            try
            {

                contexto.Funcionario.Add(funcionario);
                contexto.SaveChanges();
                return CreatedAtRoute("GetFuncionario", new { id = funcionario.Id }, funcionario);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }
        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] Funcionario funcionario)
        {
            if (funcionario == null|| funcionario.Id != id) {
                return BadRequest();
            }
            funcionario.DtAlteracao = DateTime.Now;
            contexto.Entry(funcionario).State = EntityState.Modified;

            contexto.Entry(funcionario.Pessoa).State = EntityState.Modified;

            contexto.Entry(funcionario.Cargo).State = EntityState.Modified;

            contexto.Entry(funcionario.Conselho).State = EntityState.Modified;

            contexto.Entry(funcionario.Usuario).State = EntityState.Modified;
            contexto.SaveChanges();
            return new NoContentResult();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var funcionario = contexto.Funcionario.FirstOrDefault(x => x.Id == id);
            if (funcionario == null)
            {
                return NotFound();
            }
            contexto.Pessoa.FirstOrDefault(x => x.Id == id);
            contexto.Cargo.FirstOrDefault(x => x.Id == funcionario.IdCargo);
            contexto.Usuario.FirstOrDefault(x => x.Id == id);
            contexto.Conselho.FirstOrDefault(x => x.Id == id);
            if (funcionario == null)
            {
                return BadRequest();
            }
            
            try
            {
                
                contexto.Remove(funcionario.Usuario);
                contexto.Remove(funcionario.Conselho);
                contexto.Remove(funcionario);
                contexto.Remove(funcionario.Cargo);
                contexto.Remove(funcionario.Pessoa);
                contexto.SaveChanges();
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