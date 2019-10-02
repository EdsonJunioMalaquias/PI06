using PI06.IRepository;
using PI06.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PI06.Api.IServiceRepository.ServiceRepositories
{
    public class FuncionarioService : ServiceBase<Funcionario>, IFuncionarioService
    {
        private readonly IFuncionarioRepository _repository;

        public FuncionarioService(IFuncionarioRepository repository) : base(repository)
        {
            _repository = repository;
        }
        public IEnumerable<Funcionario> GetAllIncludingProperties()
        {
            return _repository.GetAllIncludingProperties();
        }

        public Funcionario GetByIdIncludingProperties(int id)
        {
            return _repository.GetByIdIncludingProperties(id);
        }
        public Funcionario GetByCpfIncludingProperties(string cpf)
        {
            return _repository.GetByCPFIncludingProperties(cpf);
        }

        public void Salvar(Funcionario funcionario)
        {
            _repository.Salvar(funcionario);
        }
    }
}
