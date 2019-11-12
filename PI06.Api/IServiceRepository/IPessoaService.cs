using PI06.Models.Entity;
using System.Collections.Generic;

namespace PI06.Api.IServiceRepository
{
    public interface IPessoaService : IServiceBase<Pessoa>
    {
        IEnumerable<Pessoa> GetAllIncludingProperties();

    }
}
