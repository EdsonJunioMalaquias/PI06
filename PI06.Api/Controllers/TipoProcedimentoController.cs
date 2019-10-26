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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PI06.Api.Controllers
{
    [Route("api/[controller]")]
    public class TipoProcedimentoController : Controller
    {
        private readonly ITipoProcedimentoService _tProcedimentoService;

        public TipoProcedimentoController (ITipoProcedimentoService tipoProcedimentoService)
        {
            _tProcedimentoService = tipoProcedimentoService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(TipoProcedimento), 200)]
        public async Task<IActionResult> Get() {
            var consultaAll = await _tProcedimentoService.GetAllAsync();
            return Json(consultaAll);
        }
       

    }
}
