using PI06.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PI06.Data.Models.Entity
{
    public  class TipoExame: EntityBase
    {
        public string Descricao { get; set; }
        public string ResultadoReferencia { get; set; }
        public virtual ICollection<Exame> Exames { get; set; }
    }
}
