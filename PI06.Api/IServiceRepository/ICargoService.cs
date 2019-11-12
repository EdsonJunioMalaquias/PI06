using PI06.Models.Entity;
using System.Collections.Generic;

namespace PI06.Api.IServiceRepository
{
    public interface ICargoService : IServiceBase<Cargo>
    {
        IEnumerable<Cargo> GetAllDistinct();
    }
}
