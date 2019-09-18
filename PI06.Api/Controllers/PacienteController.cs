namespace PI06.Api.Controllers
{
    [Route("api/[controller]")]
    public class PacienteController
    {
        private readonly Contexto contexto;

        public PacienteController(Contexto contexto)
        {
            this.contexto = contexto;
        }
        [HttpGet("{id}", Name = "GetPaciente")]
        [ProducesResponseType(typeof(Paciente), 200)]
        public IActionResult Get(int id)
        {
            var paciente = contexto.Paciente.FirstOrDefault(x => x.Id == id);
            if (paciente == null) {
                return NotFound();
            }
            contexto.Pessoa.FirstOrDefault(x => x.Id == id);

            return Json(paciente);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Paciente), 200)]
        public IActionResult Get()
        {

            var paciente = contexto.Paciente.ToList();
            if (paciente == null)
            {
                return NotFound();
            }
            foreach (var item in paciente)
            {
                item.Pessoa = contexto.Pessoa.FirstOrDefault(x => x.Id == item.Id);
            }
            return Json(paciente);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Paciente paciente) {

            if (paciente == null) {
                return BadRequest();
            }
            paciente.DtInclusao = DateTime.Now;
            contexto.Set<Paciente>().Add(paciente);
            try
            {
                contexto.Paciente.Add(paciente);
                contexto.SaveChanges();
                return CreatedAtRoute("GetPaciente", new { id = paciente.Id }, paciente);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }
        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] Paciente paciente)
        {
            if (paciente == null|| paciente.Id != id) {
                return BadRequest();
            }
            paciente.DtAlteracao = DateTime.Now;
            contexto.Entry(paciente).State = EntityState.Modified;

            contexto.Entry(paciente.Pessoa).State = EntityState.Modified;

            contexto.SaveChanges();
            return new NoContentResult();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var paciente = contexto.Paciente.FirstOrDefault(x => x.Id == id);
            if (paciente == null)
            {
                return NotFound();
            }
            contexto.Pessoa.FirstOrDefault(x => x.Id == id);

            if (paciente == null)
            {
                return BadRequest();
            }
            
            try
            {
                
                contexto.Remove(paciente);
                contexto.Remove(paciente.Pessoa);
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