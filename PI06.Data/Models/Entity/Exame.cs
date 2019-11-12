using Newtonsoft.Json;
using PI06.Models.Entity;

namespace PI06.Data.Models.Entity
{
    public class Exame : EntityBase
    {
        public string Resultado { get; set; }
        public TipoExame TipoExame { get; set; }
        public int IdTipoExame { get; set; }
        [JsonIgnore]
        public Procedimento Procedimento { get; set; }
    }
}
