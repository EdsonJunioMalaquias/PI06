using System;
using System.Collections.Generic;
using System.Text;
using PI06.IRepository;
using PI06.Models.Entity;

namespace PI06.Data.IRepository
{
   public interface ICargoRepository : IRepository<Cargo> 
    {

        IEnumerable<Cargo> GetAllDistinct();
    }
}
