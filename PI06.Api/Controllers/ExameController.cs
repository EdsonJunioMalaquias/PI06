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
        private readonly IExameService _exameService;

        public ExameController(IExameService exameService) {

            _exameService = exameService;


        }

        [HttpGet]
        [ProducesResponseType(typeof(Exame), 200)]
        public async Task<IActionResult> Get() {

            var consultaAll = await _exameService.GetAllAsync();

            return Json(consultaAll);

        }

        [HttpPost]
        public IActionResult Post([FromRoute] Exame exame)
        {
            if (exame == null) {

                return BadRequest();
            }


            try {
                _exameService.AddAsync(exame);
                return CreatedAtRoute("GetExame", new { id = exame.Id }, exame);


            } catch (Exception e){
                Console.WriteLine(e.Message);
                throw;

            }


        }


    }
}
