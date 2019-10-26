using System;
using Microsoft.AspNetCore.Mvc;
using PI06.Data.Context;
using PI06.Models.Entity;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using PI06.Api.IServiceRepository;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PI06.Api.Controllers
{
    [Route("api/[controller]")]
    public class PessoaController : Controller
    {
        private readonly IPessoaService _pessoaService;
        public PessoaController(IPessoaService pessoaService) {

            _pessoaService = pessoaService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(Pessoa), 200)]
        public IActionResult Get()
        {
            var consultaAll = _pessoaService.GetAllIncludingProperties();

            return Json(consultaAll);

        }



    }
}
