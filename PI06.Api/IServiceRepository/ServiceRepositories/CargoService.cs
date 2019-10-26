using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PI06.Models.Entity;
using PI06.Data.IRepository;

namespace PI06.Api.IServiceRepository.ServiceRepositories
{
    public class CargoService : ServiceBase<Cargo>, ICargoService
    {
        private readonly ICargoRepository _repository;
        public CargoService(ICargoRepository repository) : base(repository)
        {

            _repository = repository;
        }

        public IEnumerable<Cargo> GetAllDistinct()
        {
            return _repository.GetAllDistinct();
        }
    }
}
