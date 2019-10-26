using PI06.Data.IRepository;
using PI06.Data.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PI06.Api.IServiceRepository.ServiceRepositories
{
    public class ConsultaService : ServiceBase<Consulta>, IConsultaService
    {
        private readonly IConsultaRepository _repository;

        public ConsultaService(IConsultaRepository respository) : base(respository) {
            _repository = respository;
        }



      public  IEnumerable<Consulta> GetAllIncludingProperties(int idPaciente)
        {
            return _repository.GetAllConsultasByIdPaciente(idPaciente);
        }
    }
}
