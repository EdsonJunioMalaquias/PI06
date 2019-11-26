using Microsoft.EntityFrameworkCore;
using PI06.Data.Context;
using PI06.Data.Models.Entity;
using PI06.IRepository.Repository;
using System.Collections.Generic;
using System.Linq;

namespace PI06.Data.IRepository.Repositories
{
    public class AtendimentoRepository : Repository<Atendimento>, IAtendimentoRepository
    {

        public AtendimentoRepository(Contexto context) : base(context)
        {
        }
        public IEnumerable<Atendimento> GetByFuncionarioIncludeAllProperity(int idMedico)
        {

            IQueryable<Atendimento> query = dbSet
                        .Include(d => d.Medico)
                        .ThenInclude(e => e.Pessoa)
                        
                        .Include(d => d.Paciente)
                        .ThenInclude(e => e.Pessoa)
                        .Where(f => f.MedicoId == idMedico);

            return query.AsEnumerable();
        }

        public IEnumerable<Atendimento> GetIncludeAllProperity()
        {
            IQueryable<Atendimento> query = dbSet
                                    
                                        .Include(d => d.Medico)
                                        .ThenInclude(e => e.Pessoa)

                                    
                                        .Include(d => d.Paciente)
                                        .ThenInclude(e => e.Pessoa);

            return query.AsEnumerable();
        }

    }
}
