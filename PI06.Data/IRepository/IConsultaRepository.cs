using PI06.Data.Models.Entity;
using PI06.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PI06.Data.IRepository
{
   public interface IConsultaRepository : IRepository<Consulta>
    {

         IEnumerable<Consulta> GetAllConsultasByIdPaciente(int id);









    }
}
