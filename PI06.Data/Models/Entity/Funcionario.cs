using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using PI06.Data.Models.Entity;

namespace PI06.Models.Entity {
    public class Funcionario : EntityBase {
        [Required (ErrorMessage = "A data de contratação é Obrigatoria!")]
        public DateTime DataContratacao { get;  set; }
        public DateTime? DataDemissao { get;  set; }
        public Cargo Cargo { get;  set; }
        public Conselho Conselho { get;  set; }
        public Pessoa Pessoa { get; set; }
         public ICollection<Consulta> Consultas { get; set; }
        public int CargoId { get; set; }
        public int? ConselhoId { get; set; }
        protected Funcionario () {

        }
        public Funcionario (
            DateTime dataContratacao, DateTime? dataDemissao, Cargo cargo, Conselho  conselho,Pessoa pessoa) {
            
            SetDataContratacao (dataContratacao);
            SetDataDemissao (dataDemissao);

            SetCargo(cargo.IsHealthProfession, cargo);
            if (cargo.IsHealthProfession) {
                Conselho = conselho;
            } else {
                Conselho = null;
            }
            this.Pessoa = pessoa;
        }

        public void SetCargo (Boolean IsHealthProfession, Cargo cargo) {
            if (IsHealthProfession && Conselho == null) {
                throw new Exception ("Conselho não pode estar vazio se o cargo for de um profissiona da saúde!");
            }
            this.Cargo = cargo;
        }
        public void SetDataDemissao (DateTime? data) {
            DataDemissao = data;
        }
        public void SetDataContratacao (DateTime data) {
            if (data == null) {
                throw new Exception ("A data de Contratação é invalida!");
            } else {
                DataContratacao = data;
            }
        }

    }
}