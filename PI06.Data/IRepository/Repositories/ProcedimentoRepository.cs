using System;
using System.Linq;
using PI06.Data.Context;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PI06.Helpers;
using PI06.Data.Models.Entity;
using PI06.IRepository.Repository;

namespace PI06.Data.IRepository.Repository
{
    public class ProcedimentoRepository : Repository<Procedimento>, IProcedimentoRepository
    {
        public ProcedimentoRepository(Contexto context) : base(context)
        {



        }

    }
}
