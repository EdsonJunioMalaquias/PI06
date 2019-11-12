using PI06.IRepository;
using PI06.Models.Entity;
using System.Collections.Generic;

namespace PI06.Data.IRepository
{
    public interface IPacienteRepository : IRepository<Paciente>
    {
        Paciente GetByIdIncludingProperties(int id);

        IEnumerable<Paciente> GetAllIncludingProperties();
        Paciente GetByCPFIncludingProperties(string cpf);
    }
}
