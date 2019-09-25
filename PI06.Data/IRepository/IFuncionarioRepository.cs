using System;
using PI06.Models.Entity;
using System.Collections.Generic;

namespace PI06.IRepository
{
    public interface IFuncionarioRepository : IRepository<Funcionario>
    {
        bool CpfJaCadastrado(Int64 cpf, int usuarioId);
        bool LoginJaCadastrado(string login, int usuarioId);
        Funcionario Get(string login);
        void Salvar(Funcionario usuario);
        IEnumerable<Funcionario> GetAllIncludingProperties();
        Funcionario GetByIdIncludingProperties(int id);
    }
}