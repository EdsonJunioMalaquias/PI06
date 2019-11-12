using PI06.Data.IRepository;
using PI06.Data.Models.Entity;

namespace PI06.Api.IServiceRepository.ServiceRepositories
{
    public class TipoExameService : ServiceBase<TipoExame>, ITipoExameService
    {
        private readonly ITipoExameRepository _repository;

        public TipoExameService(ITipoExameRepository repository) : base(repository)
        {

            _repository = repository;
        }

    }
}
