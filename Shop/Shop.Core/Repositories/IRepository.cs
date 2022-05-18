using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Repositories
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, params string[] includes);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression, params string[] includes);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);
        void Remove(TEntity entity);
        Task<int> CommitAsync();
        int Commit();
    }
}
