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
    public class ProcedimentoController : Controller
    {
        private readonly IProcedimentoService _ProcedimentoService;

        public ProcedimentoController(IProcedimentoService procedimentoService) {

            _ProcedimentoService = procedimentoService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(Procedimento), 200)]
        public async Task<IActionResult> Get() {

            var consultaAll = await _ProcedimentoService.GetAllAsync();

            return Json(consultaAll);
        }








    }
}
