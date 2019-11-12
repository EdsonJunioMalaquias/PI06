using PI06.Models.Entity;
using System.Collections.Generic;

namespace PI06.Api.IServiceRepository
{
    public interface IPacienteService : IServiceBase<Paciente>
    {
        Paciente GetByIdIncludingProperties(int id);
        IEnumerable<Paciente> GetAllIncludingProperties();
        Paciente GetByCPFIncludingProperties(string cpf);
    }
}
