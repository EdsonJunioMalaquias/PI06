using PI06.Data.IRepository;
using PI06.Data.Models.Entity;
using System.Collections.Generic;

namespace PI06.Api.IServiceRepository.ServiceRepositories
{
    public class AtendimentoService : ServiceBase<Atendimento>, IAtendimentoService
    {
        private readonly IAtendimentoRepository _repository;
        public AtendimentoService(IAtendimentoRepository repository) : base(repository)
        {

            _repository = repository;
        }
        public IEnumerable<Atendimento> GetByFuncionarioIncludeAllProperity(int idMedico)
        {
            return _repository.GetByFuncionarioIncludeAllProperity(idMedico);
        }

        public IEnumerable<Atendimento> GetIncludeAllProperity()
        {
            return _repository.GetIncludeAllProperity();
        }

    }
}
