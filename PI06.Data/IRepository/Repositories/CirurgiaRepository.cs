using PI06.Data.Context;
using PI06.Data.IRepository;
using PI06.Data.Models.Entity;

namespace PI06.IRepository.Repository

{
    public class CirurgiaRepository : Repository<Cirurgia>, ICirurgiaRepository
    {
        public CirurgiaRepository(Contexto context) : base(context)
        {
        }
    }
}
