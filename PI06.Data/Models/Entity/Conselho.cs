using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using PI06.Helpers;
using System;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace PI06.Models.Entity {
    public class Conselho : EntityBase {
        public int? NumeroConselho { get; set; }
        public String DescricaoConselho { get;  set; }
        [JsonIgnore]
        public Funcionario Funcionario { get;  set; }

        public Conselho (int? numeroConselho, string descricaoConselho) {
            SetNumeroConselho (numeroConselho);
            SetDescricaoConselho (descricaoConselho);
            DtInclusao = DateTime.Now;
        }

        public void SetNumeroConselho (int? numeroConselho) {
            if (numeroConselho <= 100) {
                throw new Exception ("Numero Conselho invalido!");
            }
            
            this.NumeroConselho = numeroConselho;
        }
        public void SetDescricaoConselho (String descricaoConselho) {
            this.DescricaoConselho = descricaoConselho;
        }
    }
}