using System.Linq.Expressions;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using netCore.RateLimiting.Application.Repositories;
using netCore.RateLimiting.Models.Common;

namespace netCore.RateLimiting.Persistence.Repositories
{
    public class BaseRepository<TEntity, TContex> : IBaseRepository<TEntity>
    where TEntity : BaseEntity where TContex : DbContext
    {
        private readonly TContex _context;

        public BaseRepository(TContex context)
        {
            _context = context;
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>>? predicate = null)
        {
            return predicate == null
                ? await _context.Set<TEntity>().ToListAsync()
                : await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
    }
}
