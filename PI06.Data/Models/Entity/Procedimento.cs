using PI06.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PI06.Data.Models.Entity
{
    public class Procedimento : EntityBase
    {
        public string Observacao{ get; set;}
        public Exame Exame { get; set; }

        public TipoProcedimento TipoProcedimento { get; set; }

        public Consulta Consulta { get; set; }

        public Cirurgia Cirurgia { get; set; }

        public int IdConsulta { get; set; }
        public int IdTipoProcedimento { get; set; }




    }
}
