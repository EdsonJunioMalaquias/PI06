using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using PI06.Models.Entity;
using PI06.IRepositories;
using System.Text;

namespace PI06.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public void Add(TEntity obj)
        {
            obj.DtInclusao = DateTime.Now;
            Context.Set<TEntity>().Add(obj);
        }

        public void AddAll(IEnumerable<TEntity> obj)
        {
            foreach (var entity in obj)
                Add(entity);
        }

        public void DeleteAll(IEnumerable<TEntity> obj)
        {
            foreach (var entity in obj)
                Delete(entity);
        }

        public void Delete(TEntity obj)
        {
            Context.Set<TEntity>().Remove(obj);
        }

        public void Delete(int id)
        {
            Context.Set<TEntity>().Remove(Get(id));
        }

        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public TEntity First()
        {
            return Context.Set<TEntity>().FirstOrDefault();
        }

        public IEnumerable<TEntity> Get()
        {
            return Context.Set<TEntity>().ToList();
        }

        public void Update(TEntity obj)
        {
            obj.DtAlteracao = DateTime.Now;
            Context.Entry(obj).State = EntityState.Modified;
        }

        public void AddOrUpdate(TEntity obj)
        {
            if (obj.Id > 0)
                Update(obj);
            else
                Add(obj);
        }

        public void Commit()
        {
            try
            {
                Context.SaveChanges();
            }          
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}