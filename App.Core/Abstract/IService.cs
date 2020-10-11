using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace App.Core.Abstract
{
    public interface IService<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Table { get; }
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteAsync(object id);
        Task SaveAsync();
        Task<TEntity> GetByIdAsync(object id);
    }
}
