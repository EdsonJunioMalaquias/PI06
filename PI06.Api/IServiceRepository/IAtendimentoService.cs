using PI06.Data.Models.Entity;
using System.Collections.Generic;

namespace PI06.Api.IServiceRepository
{
    public interface IAtendimentoService : IServiceBase<Atendimento>
    {
        IEnumerable<Atendimento> GetByFuncionarioIncludeAllProperity(int idMedico);
        IEnumerable<Atendimento> GetIncludeAllProperity();
    }
}
