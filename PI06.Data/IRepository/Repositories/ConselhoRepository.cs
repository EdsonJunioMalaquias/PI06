using PI06.Data.Context;
using PI06.Data.IRepository;
using PI06.Models.Entity;

namespace PI06.IRepository.Repository
{
    public class ConselhoRepository : Repository<Conselho>, IConselhoRepository
    {
        public ConselhoRepository(Contexto context) : base(context)
        {
        }

    }
}
