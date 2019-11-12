using PI06.Data.IRepository;
using PI06.Models.Entity;
using System.Collections.Generic;

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
