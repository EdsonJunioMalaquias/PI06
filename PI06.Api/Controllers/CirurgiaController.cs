using System;
using Microsoft.AspNetCore.Mvc;
using PI06.Data.Context;
using PI06.Models.Entity;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using PI06.Api.IServiceRepository;
using System.Threading.Tasks;
using PI06.Data.Models.Entity;

namespace PI06.Api.Controllers
{
    [Route("api/[controller]")]
    public class CirurgiaController : Controller
    {
        private readonly ICirurgiaService _cirurgiaService;

        public CirurgiaController(ICirurgiaService cirurgiaService)
        {
            _cirurgiaService = cirurgiaService;

        }


        [HttpGet]
        [ProducesResponseType(typeof(Cirurgia), 200)]
        public async Task<IActionResult> Get() {

            var consultaAll = await _cirurgiaService.GetAllAsync();

            return Json(consultaAll);

        }

        public IActionResult Post([FromBody] Cirurgia cirurgia) {
            if (cirurgia == null) {

                return BadRequest();

            }
            try
            {
                _cirurgiaService.AddAsync(cirurgia);
                return CreatedAtRoute("GetCirurgia", new { id = cirurgia.Id }, cirurgia);
            }
            catch (Exception c) {

                Console.WriteLine(c.Message);
                throw;
            }


        }



    }






}
