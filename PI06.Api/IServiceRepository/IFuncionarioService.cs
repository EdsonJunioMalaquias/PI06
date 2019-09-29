using PI06.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PI06.Api.IServiceRepository
{

    public interface IFuncionarioService : IServiceBase<Funcionario>
    {
        IEnumerable<Funcionario> GetAllIncludingProperties();
        Funcionario GetByIdIncludingProperties(int id);
        
        Funcionario GetByCpfIncludingProperties(string cpf);

    }

}
