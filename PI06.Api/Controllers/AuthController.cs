using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PI06.Data.Context;
using System.Linq;
using PI06.Models.Entity;

namespace PI06.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly Contexto contexto;
        private readonly SignInManager<Usuario> _signInManager;

        public AuthController(Contexto contexto, SignInManager<Usuario> signInManager)
        {
            this.contexto = contexto;
            this._signInManager = signInManager;
        }

        // GET api/values/5
        [HttpGet]
        public IActionResult Get([FromBody] string usuario)
        {
            var u = contexto.Usuario.FirstOrDefault(x => x.Login.Equals(usuario));
            if (u == null)
            {
                return BadRequest();
            }
            return Json(u);
        }
    }
}
