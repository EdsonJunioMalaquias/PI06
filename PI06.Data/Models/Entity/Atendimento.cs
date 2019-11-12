using Newtonsoft.Json;
using PI06.Models.Entity;
using System;

namespace PI06.Data.Models.Entity
{
    public class Atendimento : EntityBase
    {
        public int GrauDeEmergencia { get; set; }
        public Paciente Paciente { get; set; }
        public DateTime DataChegada { get; set; }
        public bool StatusDeAtendimento { get; set; }
        public Funcionario Medico { get; set; }
        [JsonIgnore]
        public Fila Fila { get; set; }

        public int FilaId { get; set; }
        public int MedicoId { get; set; }
        public int PacienteId { get; set; }


    }
}
