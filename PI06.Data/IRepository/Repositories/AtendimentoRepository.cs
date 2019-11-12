using PI06.Data.Context;
using PI06.Data.Models.Entity;
using PI06.IRepository.Repository;

namespace PI06.Data.IRepository.Repositories
{
    public class AtendimentoRepository : Repository<Atendimento>, IAtendimentoRepository
    {

        public AtendimentoRepository(Contexto context) : base(context)
        {
        }


    }
}
