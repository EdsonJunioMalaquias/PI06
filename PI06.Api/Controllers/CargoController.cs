using Microsoft.AspNetCore.Mvc;
using PI06.Data.Context;
using PI06.Models.Entity;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PI06.Data;

namespace PI06.Api.Controllers
{
    [Route("api/[controller]")]
    public class CargoController
    {
        private readonly Contexto contexto;

        public CargoController(Contexto contexto)
        {
            this.contexto = contexto;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Cargo), 200)]
        public IActionResult Get(int id)
        {
            var cargo = contexto.Cargo.FirstOrDefault(
                x => x.Id == id);


            return new ObjectResult(cargo);
        }
    }

    }
