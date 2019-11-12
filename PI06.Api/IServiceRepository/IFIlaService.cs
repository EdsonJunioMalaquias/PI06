using PI06.Data.Models.Entity;
using System.Collections.Generic;

namespace PI06.Api.IServiceRepository
{
    public interface IFilaService : IServiceBase<Fila>
    {
        IEnumerable<Fila> GetByFuncionarioIncludeAllProperity(int idMedico);
        IEnumerable<Fila> GetIncludeAllProperity();
    }
}
