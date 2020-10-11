using App.Core.Abstract;
using App.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace App.Core.Concrete
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        protected readonly DataContext _context;
        private DbSet<TEntity> _entities;

        public Service(DataContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public IQueryable<TEntity> Table => _entities;

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await _entities.FindAsync(id);
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
            await SaveAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _entities.Update(entity);
            await SaveAsync();
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            _entities.Remove(entity);
            await SaveAsync();
        }

        public virtual async Task DeleteAsync(object id)
        {
            TEntity entity = await GetByIdAsync(id);
            _entities.Remove(entity);
            await SaveAsync();
        }

        public virtual async Task SaveAsync()
        {
            using (var db_contextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync();
                    await db_contextTransaction.CommitAsync();
                }
                catch (Exception)
                {
                    //Log kaydı tutulabilir.                    
                    //returnValue = false;
                    await db_contextTransaction.RollbackAsync();
                    throw;
                }
            }
        }
    }
}
