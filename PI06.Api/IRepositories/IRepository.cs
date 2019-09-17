using System.Collections.Generic;
using System.Linq;
using PI06.Models.Entity;

namespace PI06.IRepositories
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        void Add(TEntity obj);
        void AddAll(IEnumerable<TEntity> obj);
        void DeleteAll(IEnumerable<TEntity> obj);
        void Delete(TEntity obj);
        void Delete(int id);

        TEntity Get(int id);

        TEntity First();
        IEnumerable<TEntity> Get();
        void Update(TEntity obj);

        void Commit();

        void AddOrUpdate(TEntity obj);
    }
}