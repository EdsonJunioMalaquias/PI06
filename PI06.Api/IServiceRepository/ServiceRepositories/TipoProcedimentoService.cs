using PI06.Data.IRepository;
using PI06.Data.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PI06.Api.IServiceRepository.ServiceRepositories
{
    public class TipoProcedimentoService : ServiceBase<TipoProcedimento>, ITipoProcedimentoService

    {

        private readonly ITipoProcedimentoRepository _repository;

        public TipoProcedimentoService(ITipoProcedimentoRepository repository) : base(repository){

            _repository = repository;

        }

    }
}
