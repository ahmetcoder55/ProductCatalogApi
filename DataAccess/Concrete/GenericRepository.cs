using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
    where TEntity : class, IEntity
    where TContext : DbContext
    {
        //DI=Dependency Injection
        protected readonly TContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(TContext context)
        {
            _context = context;
            _dbSet=_context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
           await _dbSet.AddAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
           return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}