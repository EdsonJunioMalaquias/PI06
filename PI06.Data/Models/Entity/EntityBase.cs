using System;
using System.Collections.Generic;
using System.Text;

namespace PI06.Models.Entity {
    public abstract class EntityBase {
        public int Id { get; set; }
        public DateTime DtInclusao { get; set; }
        public DateTime? DtAlteracao { get; set; }
    }
}