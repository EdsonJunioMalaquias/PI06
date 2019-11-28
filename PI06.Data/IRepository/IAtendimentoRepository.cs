using PI06.Data.Models.Entity;
using PI06.IRepository;
using System.Collections.Generic;

namespace PI06.Data.IRepository
{
    public interface IAtendimentoRepository : IRepository<Atendimento>
    {
        IEnumerable<Atendimento> GetByFuncionarioIncludeAllProperity(int idMedico);
        IEnumerable<Atendimento> GetIncludeAllProperity();
    }
}
