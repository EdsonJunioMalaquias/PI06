using Microsoft.EntityFrameworkCore;
using PI06.Data.Context;
using PI06.Data.IRepository;
using PI06.IRepository.Repository;
using PI06.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PI06.Data.IRepository.Repositories
{
    public class PacienteRepository : Repository<Paciente>, IPacienteRepository
    {

        public PacienteRepository(Contexto context) : base(context)
        {
        }

        public Paciente GetByCPFIncludingProperties(string cpf)
        {
            var pessoa = _contexto.Pessoa.FirstOrDefault(x => x.CodigoCpf == Pessoa.GetLongCpf(cpf));
            if (pessoa is null)
            {
                return null;
            }
            return GetByIdIncludingProperties(pessoa.Id);
        }

        public Paciente GetByIdIncludingProperties(int id)
        {
            IQueryable<Paciente> query = dbSet.Include(p => p.Pessoa).Where(i => i.Id == id);
            return query.FirstOrDefault();
        }
    }
}
