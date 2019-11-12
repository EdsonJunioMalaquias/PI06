using PI06.Data.Context;
using PI06.Data.Models.Entity;
using PI06.IRepository.Repository;

namespace PI06.Data.IRepository.Repository
{
    public class ExameRepository : Repository<Exame>, IExameRepository
    {

        public ExameRepository(Contexto context) : base(context)
        {
        }



    }
}
