using PI06.Models.Entity;
using System.Collections.Generic;

namespace PI06.Api.IServiceRepository
{

    public interface IFuncionarioService : IServiceBase<Funcionario>
    {
        IEnumerable<Funcionario> GetAllIncludingProperties();
        Funcionario GetByIdIncludingProperties(int id);
        IEnumerable<Funcionario> GetAllIncludingProperties(string cargo);
        void Salvar(Funcionario usuario);
        Funcionario GetByCpfIncludingProperties(string cpf);

    }

}
