using PI06.Data.IRepository;
using PI06.Data.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PI06.Api.IServiceRepository.ServiceRepositories
{
    public class ProcedimentoService : ServiceBase<Procedimento>, IProcedimentoService
    {


        private readonly IProcedimentoRepository _repository;

        public ProcedimentoService(IProcedimentoRepository repository) : base(repository)
        {
            _repository = repository;

        }

    }
}
