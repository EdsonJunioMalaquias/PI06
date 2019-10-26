using Newtonsoft.Json;
using PI06.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PI06.Data.Models.Entity
{
    public class TipoProcedimento : EntityBase
    {

        public string Descricao { get; set; }
        [JsonIgnore]
        public virtual ICollection<Procedimento> Procedimentos { get; set; }



    }
}
