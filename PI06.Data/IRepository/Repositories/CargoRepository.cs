using PI06.Data.Context;
using PI06.IRepository.Repository;
using PI06.Models.Entity;
using System.Collections.Generic;
using System.Linq;

namespace PI06.Data.IRepository.Repository
{
    public class CargoRepository : Repository<Cargo>, ICargoRepository
    {
        public CargoRepository(Contexto context) : base(context)
        {

        }
        public IEnumerable<Cargo> GetAllDistinct()
        {
            IQueryable<Cargo> query = dbSet.Distinct();
            return query.AsEnumerable();
        }
    }
}
