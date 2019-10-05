using PI06.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PI06.Data.Models.Entity
{
  public  class Cirurgia: EntityBase
    {
        public Procedimento Procedimento { get; set; }
        public string Descricao { get; set; }
    }
}
