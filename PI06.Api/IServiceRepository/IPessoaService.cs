using PI06.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PI06.Api.IServiceRepository
{
    public interface IPessoaService :IServiceBase<Pessoa>
    {
        IEnumerable<Pessoa> GetAllIncludingProperties();

    }
}
