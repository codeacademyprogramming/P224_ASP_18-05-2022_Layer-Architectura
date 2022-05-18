using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace P224RepositoryPattern.Repositories
{
    public interface IRepository<TEntity>
    {
        Task AddAsync(TEntity entity);

        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);

        Task<int> CommitAsync();

        int Commit();

        void Remove(TEntity entity);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);
    }
}
