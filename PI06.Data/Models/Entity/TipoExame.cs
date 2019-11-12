using Newtonsoft.Json;
using PI06.Models.Entity;
using System.Collections.Generic;

namespace PI06.Data.Models.Entity
{
    public class TipoExame : EntityBase
    {
        public string Descricao { get; set; }
        public string ResultadoReferencia { get; set; }
        [JsonIgnore]
        public virtual ICollection<Exame> Exames { get; set; }
    }
}
