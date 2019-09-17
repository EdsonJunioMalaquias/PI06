using System;
using Microsoft.AspNetCore.Mvc;
using PI06.Data.Context;
using PI06.Models.Entity;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PI06.IRepositories;
using Newtonsoft.Json;

namespace PI06.Api.Controllers
{
    
    [Route("api/[controller]")]
    public class FuncionarioController:Controller
    {
        private readonly Contexto contexto;

        public FuncionarioController(Contexto contexto)
        {
            this.contexto = contexto;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Funcionario), 200)]
        public IActionResult Get(int id)
        {
            var funcionario = contexto.Funcionario.FirstOrDefault(x => x.Id == id);
            if(funcionario == null ){
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
        public IEnumerable<Funcionario> Get()
        {

            var funcionario = contexto.Funcionario.ToList();
            foreach (var item in funcionario)
            {
                item.Cargo = contexto.Cargo.FirstOrDefault(x => x.Id == item.IdCargo);
                item.Conselho = contexto.Conselho.FirstOrDefault(x => x.Id == item.Id);
                item.Usuario = contexto.Usuario.FirstOrDefault(x => x.Id == item.Id);
                item.Pessoa = contexto.Pessoa.FirstOrDefault(x => x.Id == item.Id);
            }
            return funcionario;
        }
        [HttpPost]
        public IActionResult Post([FromBody] Funcionario funcionario){

            if(funcionario == null){
                return BadRequest();
            }
            funcionario.DtInclusao = DateTime.Now;
            contexto.Set<Funcionario>().Add(funcionario);
        
        }





    }
}