using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PI06.Models.Entity
{
    public class Paciente : EntityBase {
        [JsonIgnore]
        public Pessoa Pessoa { get; set; }
     }
}