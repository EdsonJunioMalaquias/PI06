using Newtonsoft.Json;
using PI06.Data.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PI06.Models.Entity
{
    public class Funcionario : EntityBase
    {
        [Required(ErrorMessage = "A data de contratação é Obrigatoria!")]
        public DateTime DataContratacao { get; set; }
        public DateTime? DataDemissao { get; set; }
        public Cargo Cargo { get; set; }
        public Conselho Conselho { get; set; }
        public Pessoa Pessoa { get; set; }
        [JsonIgnore]
        public ICollection<Consulta> Consultas { get; set; }
        [JsonIgnore]
        public ICollection<Atendimento> Atendimentos { get; set; }
        public int CargoId { get; set; }
        public int? ConselhoId { get; set; }



        public void SetCargo(Boolean IsHealthProfession, Cargo cargo)
        {
            if (IsHealthProfession && Conselho == null)
            {
                throw new Exception("Conselho não pode estar vazio se o cargo for de um profissiona da saúde!");
            }
            this.Cargo = cargo;
        }
        public void SetDataDemissao(DateTime? data)
        {
            DataDemissao = data;
        }
        public void SetDataContratacao(DateTime data)
        {
            if (data == null)
            {
                throw new Exception("A data de Contratação é invalida!");
            }
            else
            {
                DataContratacao = data;
            }
        }

    }
}