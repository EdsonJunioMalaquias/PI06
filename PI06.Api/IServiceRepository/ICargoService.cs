using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PI06.Models.Entity;

namespace PI06.Api.IServiceRepository
{
   public  interface ICargoService : IServiceBase<Cargo>
    {
        IEnumerable<Cargo> GetAllDistinct();
    }
}
