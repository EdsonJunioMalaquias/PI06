using PI06.Data.IRepository;
using PI06.Data.Models.Entity;

namespace PI06.Api.IServiceRepository.ServiceRepositories
{
    public class ExameService : ServiceBase<Exame>, IExameService
    {

        private readonly IExameRepository _repository;
        public ExameService(IExameRepository respository) : base(respository)
        {
            _repository = respository;
        }

    }
}
