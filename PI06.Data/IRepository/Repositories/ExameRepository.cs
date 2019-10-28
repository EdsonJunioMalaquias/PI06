using System;
using System.Linq;
using PI06.Data.Context;
using PI06.Models.Entity;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PI06.Helpers;
using PI06.IRepository.Repository;
using PI06.Data.Models.Entity;

namespace PI06.Data.IRepository.Repository
{
    public class ExameRepository : Repository<Exame>, IExameRepository
    {

        public ExameRepository(Contexto context) : base(context) 
        {
        }



    }
}
