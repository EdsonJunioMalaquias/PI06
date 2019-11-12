using PI06.Data.IRepository;
using PI06.Data.Models.Entity;

namespace PI06.Api.IServiceRepository.ServiceRepositories
{
    public class AtendimentoService : ServiceBase<Atendimento>, IAtendimentoService
    {
        private readonly IAtendimentoRepository _repository;
        public AtendimentoService(IAtendimentoRepository repository) : base(repository)
        {

            _repository = repository;
        }

    }
}
