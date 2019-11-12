using PI06.Data.Context;
using PI06.Data.Models.Entity;
using PI06.IRepository.Repository;

namespace PI06.Data.IRepository.Repository
{
    public class ProcedimentoRepository : Repository<Procedimento>, IProcedimentoRepository
    {
        public ProcedimentoRepository(Contexto context) : base(context)
        {



        }

    }
}
