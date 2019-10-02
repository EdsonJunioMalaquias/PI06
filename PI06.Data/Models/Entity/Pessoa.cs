using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using PI06.Helpers;
using PI06.Models.Enun;

namespace PI06.Models.Entity {

    public class Pessoa : EntityBase {
        private const int NumeroTelefoneMaxLength = 9;
        private const int DDDMaxLength = 3;
        private const int CepMaxLength = 8;
        private const int CPFMaxLength = 11;
        private const int EnderecoEmailMaxLength = 254;
        private const int RGMaxLength = 12;
        private const int SUSMaxLength = 10;
        [JsonIgnore]
        public Funcionario Funcionario{get;set;}
        [JsonIgnore]
        public Paciente Paciente{get;set;}
        [Required (ErrorMessage = "O nome é obrigatório!")]
        public string Nome { get; private set; }
        [Required()]
        public DateTime DataNascimento { get; private set; }
        [Required()]
        public string Rg { get; set; }
        [Required()]
        public int Sus { get; set; }
        [Required()]
        public Int64 CodigoCpf { get; set; }
        [Required()]
        public string EnderecoEmail { get; set; }
        [Required()]
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        [Required()]
        public string NumeroEndereco { get; set; }
        [Required()]
        public string Bairro { get; set; }
        [Required()]
        public string Cidade { get; set; }
        [Required()]
        public Uf Uf { get; set; }
        [Required()]
        public Int64 NumeroTelefone { get; set; }
        [Required()]
        public int DDD { get; set; }
        [Required()]
        public Int64 CepCod { get; set; }

        protected Pessoa () {

        }
        public Pessoa (string codigoCpf, DateTime dataNascimento, string enderecoemail, string sus, string rg,
            string logradouro, string complemento, string numeroEndereco, string bairro, string cidade, Uf uf, string cepCod,
            string numeroTelefone, string ddd,string nome) {
            SetSUS (sus);
            SetRG (rg);
            SetCpf (codigoCpf);
            SetEmail (enderecoemail);
            SetBairro (bairro);
            SetCidade (cidade);
            SetComplemento (complemento);
            SetLogradouro (logradouro);
            SetNumero (numeroEndereco);
            SetUf (uf);
            this.DataNascimento = dataNascimento;
            SetTelefone (numeroTelefone);
            SetDDD (ddd);
            SetCep (cepCod);
            this.Nome = nome;
        }

        private void SetRG (string rg) {
            Guard.ForNullOrEmptyDefaultMessage ("RG", rg);
            Guard.StringLength ("RG", rg, RGMaxLength);
            this.Rg = rg;
        }

        private void SetSUS (string sus) {
            Guard.ForNullOrEmptyDefaultMessage ("SUS", sus);
            sus = TextoHelper.GetNumeros (sus);
            Guard.StringLength ("SUS", sus, SUSMaxLength);
            try {
                //validador de sus
                //lacar excesao se n e sus
                Sus = Convert.ToInt32 (sus);
            } catch (Exception) {
                throw new Exception ("SUS inválido: " + sus);
            }
        }

        private void SetTelefone (string numero) {
            Guard.ForNullOrEmptyDefaultMessage ("TELEFONE", numero);
            numero = TextoHelper.GetNumeros (numero);
            Guard.StringLength ("TELEFONE", numero, NumeroTelefoneMaxLength);
            try {

                NumeroTelefone = Convert.ToInt64 (numero);
            } catch (Exception) {
                throw new Exception ("Telefone inválido: " + numero);
            }
        }

        private void SetDDD (string ddd) {
            Guard.ForNullOrEmptyDefaultMessage ("DDD", ddd);
            ddd = TextoHelper.GetNumeros (ddd);
            Guard.StringLength ("DDD", ddd, DDDMaxLength);
            try {
                DDD = Convert.ToInt32 (ddd);
            } catch (Exception) {
                throw new Exception ("DDD inválido: " + ddd);
            }
        }

        public string GetTelefoneCompleto () {
            return "" + DDD + NumeroTelefone;
        }

        public void SetCep (string cep) {
            Guard.ForNullOrEmptyDefaultMessage ("CEP", cep);
            cep = TextoHelper.GetNumeros (cep);
            Guard.StringLength ("CEP", cep, CepMaxLength);
            try {
                CepCod = Convert.ToInt64 (cep);
            } catch (Exception) {
                throw new Exception ("Cep inválido: " + cep);
            }
        }

        public string GetCepFormatado () {
            var cep = CepCod.ToString ();

            while (cep.Length < 8)
                cep = "0" + cep;

            return cep.Substring (0, 5) + "-" + cep.Substring (5);
        }

        public void SetComplemento (string complemento) {
            if (string.IsNullOrEmpty (complemento))
                complemento = "";
            Complemento = TextoHelper.ToTitleCase (complemento);
        }

        public void SetLogradouro (string logradouro) {
            Guard.ForNullOrEmptyDefaultMessage (logradouro, "Endereço");
            Logradouro = TextoHelper.ToTitleCase (logradouro);
        }

        public void SetNumero (string numero) {
            Guard.ForNullOrEmptyDefaultMessage (numero, "Número");
            NumeroEndereco = numero;
        }

        public void SetBairro (string bairro) {
            Guard.ForNullOrEmptyDefaultMessage (bairro, "Bairro");
            Bairro = TextoHelper.ToTitleCase (bairro);
        }

        public void SetCidade (string cidade) {
            Guard.ForNullOrEmptyDefaultMessage (cidade, "Cidade");
            Cidade = TextoHelper.ToTitleCase (cidade);
        }

        public void SetUf (Uf uf) {
            Uf = uf;
        }

        public string EnderecoToString () {
            return Logradouro + ", " + NumeroEndereco + " - " + Complemento + " <br /> " + Bairro + " - " + Cidade + "/" + Uf;
        }

        public void SetEmail (string endereco) {
            Guard.ForNullOrEmptyDefaultMessage (endereco, "E-mail");
            Guard.StringLength ("E-mail", endereco, EnderecoEmailMaxLength);

            if (IsEmailValid (endereco) == false)
                throw new Exception ("E-mail inválido");

            EnderecoEmail = endereco;
        }

        public static bool IsEmailValid (string email) {
            var regexEmail = new Regex (@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            return regexEmail.IsMatch (email);
        }

        public void SetCpf (string cpf) {
            Guard.ForNullOrEmptyDefaultMessage ("CPF", cpf);
            cpf = TextoHelper.GetNumeros (cpf);
            Guard.StringLength ("CPF", cpf, CPFMaxLength);
            try {
                cpf = CpfLimpo (cpf);
                if (!IsCpf (cpf))
                    throw new Exception ();
                CodigoCpf = Convert.ToInt64 (cpf);
            } catch (Exception) {
                throw new Exception ("CPF inválido: " + cpf);
            }
        }
        public static long GetLongCpf(string cpf)
        {
            Guard.ForNullOrEmptyDefaultMessage("CPF", cpf);
            cpf = TextoHelper.GetNumeros(cpf);
            Guard.StringLength("CPF", cpf, 11);
            try
            {
                cpf = CpfLimpo(cpf);
                if (!IsCpf(cpf))
                    throw new Exception();
                long _CodigoCpf = Convert.ToInt64(cpf);
                return _CodigoCpf;
            }
            catch (Exception)
            {
                throw new Exception("CPF inválido: " + cpf);
            }
        }

        public string GetCpfSemZeros () {
            return CodigoCpf.ToString ();
        }

        public static string CpfLimpo (string cpf) {
            cpf = TextoHelper.GetNumeros (cpf);

            if (string.IsNullOrEmpty (cpf))
                return "";

            while (cpf.StartsWith ("0"))
                cpf = cpf.Substring (1);

            return cpf;
        }

        public string GetCpfCompleto () {
            var cpf = CodigoCpf.ToString ();

            if (string.IsNullOrEmpty (cpf))
                return "";

            while (cpf.Length < 11)
                cpf = "0" + cpf;

            return cpf;
        }

        public static bool IsCpf (string cpf) {
            while (cpf.Length < 11)
                cpf = "0" + cpf;

            var multiplicador1 = new [] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new [] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            cpf = cpf.Trim ();
            cpf = cpf.Replace (".", "").Replace ("-", "");
            if (cpf.Length != 11)
                return false;
            var tempCpf = cpf.Substring (0, 9);
            var soma = 0;

            for (var i = 0; i < 9; i++)
                soma += int.Parse (tempCpf[i].ToString ()) * multiplicador1[i];
            var resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            var digito = resto.ToString ();
            tempCpf += digito;
            soma = 0;
            for (var i = 0; i < 10; i++)
                soma += int.Parse (tempCpf[i].ToString ()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito += resto;
            return cpf.EndsWith (digito);
        }

    }
}