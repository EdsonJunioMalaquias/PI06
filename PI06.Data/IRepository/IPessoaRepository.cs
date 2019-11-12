using PI06.IRepository;
using PI06.Models.Entity;
using System.Collections.Generic;

namespace PI06.Data.IRepository
{
    public interface IPessoaRepository : IRepository<Pessoa>
    {
        IEnumerable<Pessoa> GetAllIncludingProperties();


    }
}
