using Microsoft.EntityFrameworkCore;
using PI06.Data.Context;
using PI06.Data.Models.Entity;
using PI06.IRepository.Repository;
using System.Collections.Generic;
using System.Linq;

namespace PI06.Data.IRepository.Repositories
{
    public class FilaRepository : Repository<Fila>, IFilaRepository
    {

        public FilaRepository(Contexto context) : base(context)
        {
        }

        public IEnumerable<Fila> GetByFuncionarioIncludeAllProperity(int idMedico)
        {

            IQueryable<Fila> query = dbSet
                        .Include(p => p.Atendimentos)
                            .ThenInclude(d => d.Medico)
                            .ThenInclude(e => e.Pessoa)

                        .Include(p => p.Atendimentos)
                            .ThenInclude(d => d.Paciente)
                            .ThenInclude(e => e.Pessoa)
                        .Where(f => f.Atendimentos.All(a => a.MedicoId == idMedico));

            return query.AsEnumerable();
        }

        public IEnumerable<Fila> GetIncludeAllProperity()
        {
            IQueryable<Fila> query = dbSet
                                    .Include(p => p.Atendimentos)
                                        .ThenInclude(d => d.Medico)
                                        .ThenInclude(e => e.Pessoa)

                                    .Include(p => p.Atendimentos)
                                        .ThenInclude(d => d.Paciente)
                                        .ThenInclude(e => e.Pessoa);

            return query.AsEnumerable();
        }
    }
}
