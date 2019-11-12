using PI06.Data.IRepository;
using PI06.Data.Models.Entity;
using System.Collections.Generic;

namespace PI06.Api.IServiceRepository.ServiceRepositories
{
    public class FilaService : ServiceBase<Fila>, IFIlaService
    {
        private readonly IFilaRepository _repository;

        public FilaService(IFilaRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<Fila> GetByFuncionarioIncludeAllProperity(int idMedico)
        {
            return _repository.GetByFuncionarioIncludeAllProperity(idMedico);
        }

        public IEnumerable<Fila> GetIncludeAllProperity()
        {
            return _repository.GetIncludeAllProperity();
        }
    }
}
