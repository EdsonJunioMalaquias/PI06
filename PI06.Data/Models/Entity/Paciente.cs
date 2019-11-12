
using Newtonsoft.Json;
using PI06.Data.Models.Entity;
using System.Collections.Generic;

namespace PI06.Models.Entity
{
    public class Paciente : EntityBase
    {
        public Pessoa Pessoa { get; set; }
        public ICollection<Consulta> Consultas { get; set; }
        [JsonIgnore]
        public ICollection<Atendimento> Atendimentos { get; set; }
    }
}