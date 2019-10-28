using PI06.Data.IRepository;
using PI06.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PI06.Api.IServiceRepository.ServiceRepositories
{
    public class PessoaService : ServiceBase<Pessoa>, IPessoaService
    {
        private readonly IPessoaRepository _repository;

        public PessoaService(IPessoaRepository repository) : base(repository) {
            _repository = repository;
        }

        public IEnumerable<Pessoa> GetAllIncludingProperties()
        {
            return _repository.GetAllIncludingProperties();
        }
    }
}
