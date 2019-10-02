using PI06.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PI06.Api.IServiceRepository
{

    public interface IServiceBase<TEntity> where  TEntity : EntityBase
    {
        Task<TEntity> AddAsync(TEntity obj);
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        Task<TEntity> GetByIdAsync(object id);
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task UpdateAsync(TEntity obj);
        Task UpdateRangeAsync(IEnumerable<TEntity> entities);

        Task<bool> RemoveAsync(object id);
        Task RemoveAsync(TEntity obj);
        Task RemoveRangeAsync(IEnumerable<TEntity> entities);
    }
    
}
