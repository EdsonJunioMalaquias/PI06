using PI06.Models.Entity;
using System.Collections.Generic;

namespace PI06.Data.Models.Entity
{

    public class Fila : EntityBase
    {
        public ICollection<Atendimento> Atendimentos { get; set; }

    }
}