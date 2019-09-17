using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PI06.Models.Entity {
    public class Funcionario : EntityBase {
        [Required (ErrorMessage = "A data de contratação é Obrigatoria!")]
        public DateTime DataContratacao { get;  set; }
        public DateTime? DataDemissao { get;  set; }
        public Cargo Cargo { get;  set; }
        public Conselho Conselho { get;  set; }
        public Usuario Usuario { get; set; }
        public Pessoa Pessoa { get; set; }

        public int IdCargo { get; set; }
        protected Funcionario () {

        }
        public Funcionario (Usuario usuario,
            DateTime dataContratacao, DateTime? dataDemissao, Cargo cargo, Conselho  conselho,Pessoa pessoa) {
            Usuario = usuario;
            DtInclusao = DateTime.Now;
            SetDataContratacao (dataContratacao);
            SetDataDemissao (dataDemissao);
            if (cargo.IsHealthProfession) {
                Conselho = conselho;
            } else {
                Conselho = null;
            }
            this.Pessoa = pessoa;
            SetCargo (cargo.IsHealthProfession, cargo);
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