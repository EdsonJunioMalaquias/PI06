using Microsoft.EntityFrameworkCore;
using PI06.Data.Context;
using PI06.Data.Models.Entity;
using PI06.IRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PI06.Data.IRepository.Repositories
{
    public class TipoProcedimentoRepository : Repository<TipoProcedimento> , ITipoProcedimentoRepository 
    {
        public TipoProcedimentoRepository(Contexto context) : base(context) {

        }

    }
}

