using PI06.Data.IRepository;
using PI06.Models.Entity;

namespace PI06.Api.IServiceRepository.ServiceRepositories
{
    public class ConselhoService : ServiceBase<Conselho>, IConselhoService
    {
        private readonly IConselhoRepository _repository;
        public ConselhoService(IConselhoRepository repository) : base(repository)
        {

            _repository = repository;
        }

    }
}
