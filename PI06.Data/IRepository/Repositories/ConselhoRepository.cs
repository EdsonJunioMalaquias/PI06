using System;
using System.Linq;
using PI06.Data.Context;
using PI06.Models.Entity;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PI06.Helpers;
using PI06.Data.IRepository;

namespace PI06.IRepository.Repository
{
   public  class ConselhoRepository : Repository<Conselho> , IConselhoRepository
    {
        public ConselhoRepository(Contexto context) : base(context)
        {
        }

    }
}
