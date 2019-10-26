using Microsoft.EntityFrameworkCore;
using PI06.Data.Context;
using PI06.IRepository;
using PI06.IRepository.Repository;
using PI06.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PI06.Data.IRepository.Repositories
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(Contexto context) : base(context) {

        }

       public  IEnumerable<Pessoa> GetAllIncludingProperties()
        {
            IQueryable<Pessoa> query = dbSet.Include(p => p.Paciente).Include(f => f.Funcionario);
            return query.AsEnumerable();
        }
    }
}
