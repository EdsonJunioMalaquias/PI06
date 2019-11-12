using Newtonsoft.Json;
using PI06.Models.Entity;
using System.Collections.Generic;

namespace PI06.Data.Models.Entity
{
    public class TipoProcedimento : EntityBase
    {

        public string Descricao { get; set; }
        [JsonIgnore]
        public virtual ICollection<Procedimento> Procedimentos { get; set; }



    }
}
