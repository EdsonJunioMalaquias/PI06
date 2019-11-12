using PI06.Data.IRepository;
using PI06.Data.Models.Entity;

namespace PI06.Api.IServiceRepository.ServiceRepositories
{
    public class CirurgiaService : ServiceBase<Cirurgia>, ICirurgiaService
    {
        private readonly ICirurgiaRepository _repository;

        public CirurgiaService(ICirurgiaRepository repository) : base(repository)
        {

            _repository = repository;
        }

    }
}
