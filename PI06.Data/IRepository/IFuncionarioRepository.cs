using System;
using PI06.Models.Entity;
using System.Collections.Generic;

namespace PI06.IRepository
{
    public interface IFuncionarioRepository : IRepository<Funcionario>
    {
        void Salvar(Funcionario usuario);
        IEnumerable<Funcionario> GetAllIncludingProperties();
        IEnumerable<Funcionario> GetAllIncludingProperties(string cargo);
        Funcionario GetByIdIncludingProperties(int id);
        Funcionario GetByCPFIncludingProperties(string cpf);
    }
}