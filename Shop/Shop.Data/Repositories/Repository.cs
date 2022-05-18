using Microsoft.EntityFrameworkCore;
using Shop.Core.Entities;
using Shop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ShopDbContext _context;

        public Repository(ShopDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().AnyAsync(expression);
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, params string[] includes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (includes != null && includes.Length > 0)
            {
                foreach (string item in includes)
                {
                    //Then Include
                    //query.Include("Parent.Children");
                    //Include
                    //query.Include("Parent");
                    query.Include(item);
                }
            }

            return await query.Where(expression).ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression, params string[] includes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (includes != null && includes.Length > 0)
            {
                foreach (string item in includes)
                {
                    //Then Include
                    //query.Include("Parent.Children");
                    //Include
                    //query.Include("Parent");
                    query.Include(item);
                }
            }

            return await query.FirstOrDefaultAsync(expression);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
    }
}
