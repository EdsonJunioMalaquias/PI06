using System;
using System.Linq;
using PI06.Data.Context;
using PI06.Models.Entity;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PI06.Helpers;

namespace PI06.IRepository.Repository
{
    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository
    {

        public FuncionarioRepository(Contexto context) : base(context)
        {
        }


        public IEnumerable<Funcionario> GetAllIncludingProperties()
        {
            IQueryable<Funcionario> query = dbSet.Include(b => b.Cargo)
                                                .Include(c => c.Conselho)
                                                .Include(p => p.Pessoa);
            return query.AsEnumerable();
        }

        public Funcionario GetByIdIncludingProperties(int id)
        {
            IQueryable<Funcionario> query = dbSet.Include(b => b.Cargo)
                                                .Include(c => c.Conselho)
                                                .Include(p => p.Pessoa).Where(i => i.Id == id);
            return query.FirstOrDefault();
        }


        public bool CpfJaCadastrado(Int64 cpf, int funcionarioId)
        {
            return Get().Any(x => x.Pessoa.CodigoCpf == cpf
                                           && x.Id != funcionarioId);
        }



        public void Salvar(Funcionario funcionario)
        {
            AddOrUpdate(funcionario);
            Commit();
        }




        public Funcionario GetByCPFIncludingProperties(string cpf)
        {
            var pessoa = _contexto.Pessoa.FirstOrDefault(x => x.CodigoCpf == Pessoa.GetLongCpf(cpf));
            if(pessoa is null)
            {
                return null;
            }
            return GetByIdIncludingProperties(pessoa.Id);
        }


    }
    
}