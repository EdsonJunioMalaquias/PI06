using PI06.Data.Models.Entity;
using System.Collections.Generic;

namespace PI06.Api.IServiceRepository
{
    public interface IConsultaService : IServiceBase<Consulta>
    {

        IEnumerable<Consulta> GetAllIncludingProperties(int idPaciente);

    }
}
