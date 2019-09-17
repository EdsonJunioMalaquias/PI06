using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using PI06.Helpers;

namespace PI06.Models.Entity  {
    public class Usuario : EntityBase {
        public const int LoginMinLength = 6;
        public const int LoginMaxLength = 30;
        public const int SenhaMinLength = 6;
        public const int SenhaMaxLength = 30;
        [Required()]
        public string Login { get; set; }
        [Required()]
        public byte[] Senha { get; private set; }
        public Guid TokenAlteracaoDeSenha { get; private set; }
        [JsonIgnore]
        public Funcionario Funcionario { get; set; }
        protected Usuario () {

        }
        public Usuario (string login, string senha, string senhaConfirmacao) {
            SetLogin (login);
            SetSenha (senha, senhaConfirmacao);
        }

        public void SetLogin (string login) {
            Guard.ForNullOrEmptyDefaultMessage (login, "Login");
            Guard.StringLength ("Login", login, LoginMinLength, LoginMaxLength);
            Login = login;
        }
        private void SetSenha (string senha, string senhaConfirmacao) {
            Guard.ForNullOrEmptyDefaultMessage (senha, "Senha");
            Guard.ForNullOrEmptyDefaultMessage (senhaConfirmacao, "Confirmação de Senha");
            Guard.StringLength ("Senha", senha, SenhaMinLength, SenhaMaxLength);
            Guard.AreEqual (senha, senhaConfirmacao, "As senhas não conferem!");

            Senha = CriptografiaHelper.CriptografarSenha (senha);
        }
        public void AlterarSenha (string senhaAtual, string novaSenha, string confirmacaoDeSenha) {
            ValidarSenha (senhaAtual);
            SetSenha (novaSenha, confirmacaoDeSenha);
        }

        public void ValidarSenha (string senha) {
            Guard.ForNullOrEmptyDefaultMessage (senha, "Senha");
            var senhaCriptografada = CriptografiaHelper.CriptografarSenha (senha);
            if (!Senha.SequenceEqual (senhaCriptografada))
                throw new Exception ("Senha inválida!");
        }

        public Guid GerarNovoTokenAlterarSenha () {
            TokenAlteracaoDeSenha = Guid.NewGuid ();
            return TokenAlteracaoDeSenha;
        }

        public void AlterarSenha (Guid token, string novaSenha, string confirmacaoDeSenha) {
            if (!TokenAlteracaoDeSenha.Equals (token))
                throw new Exception ("token para alteração de senha inválido!");
            SetSenha (novaSenha, confirmacaoDeSenha);
            GerarNovoTokenAlterarSenha ();
        }

    }

}