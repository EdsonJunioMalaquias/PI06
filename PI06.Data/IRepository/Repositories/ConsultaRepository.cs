using Microsoft.EntityFrameworkCore;
using PI06.Data.Context;
using PI06.Data.IRepository;
using PI06.Data.Models.Entity;
using System.Collections.Generic;
using System.Linq;

namespace PI06.IRepository.Repository
{
    public class ConsultaRepository : Repository<Consulta>, IConsultaRepository
    {

        public ConsultaRepository(Contexto context) : base(context)
        {



        }

        public IEnumerable<Consulta> GetAllConsultasByIdPaciente(int id)
        {
            IQueryable<Consulta> query = dbSet.Include(p => p.Procedimentos)
                                                    .ThenInclude(e => e.TipoProcedimento)
                                                .Include(c => c.FuncionarioMedico)
                                                .Include(c => c.Procedimentos)
                                                    .ThenInclude(e => e.Cirurgia)
                                                .Include(c => c.Procedimentos)
                                                    .ThenInclude(e => e.Exame)
                                                        .ThenInclude(a => a.TipoExame)
                                                .Where(i => i.IdPaciente == id);
            return query.AsEnumerable();

        }
    }
}
