using PI06.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace PI06.Data.Models.Entity
{
    public class Consulta : EntityBase
    {
        public Funcionario FuncionarioMedico { get; set; }
        public Paciente Paciente { get; set; }
        public int IdPaciente { get; set; }
        public int IdFuncionarioMedico { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataTermino { get; set; }
        public ICollection<Procedimento> Procedimentos {get; set;}


    }
}
