using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;
using PI06.Helpers;

namespace PI06.Models.Entity {
    public class Cargo : EntityBase {

        public const int CargoMaxLength = 30;
        [Required()]
        public string DescricaoCargo { get;  set; }
        [Required()]
        public bool IsHealthProfession { get;  set; }
        [JsonIgnore]
        public virtual ICollection<Funcionario> Funcionarios { get; set; }
        protected Cargo () {

        }

        public Cargo (string DescricaoCargo, bool IsHealthProfession) {
            this.IsHealthProfession = IsHealthProfession;
            Guard.ForNullOrEmptyDefaultMessage ("DescricaoCargo", DescricaoCargo);

            Guard.StringLength ("DescricaoCargo", CargoMaxLength, DescricaoCargo);
            this.DescricaoCargo = DescricaoCargo;
        }

    }
}