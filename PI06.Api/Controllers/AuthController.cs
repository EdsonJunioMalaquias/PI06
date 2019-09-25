using Microsoft.AspNetCore.Mvc;
using PI06.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PI06.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly Contexto contexto;

        public AuthController(Contexto contexto)
        {
            this.contexto = contexto;
        }

        // GET api/values/5
        [HttpGet]
        public IActionResult Get([FromBody] string usuario)
        {


            //string u = "Admin";
            //string pass = "123";

            var u = contexto.Usuario.FirstOrDefault(x => x.Login.Equals(usuario));
            if (u == null)
            {
                return BadRequest();
            }
            
            return Json(u);


        }

    }
}
