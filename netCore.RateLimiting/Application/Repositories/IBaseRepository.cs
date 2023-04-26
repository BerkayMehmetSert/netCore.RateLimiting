using System.Linq.Expressions;
using netCore.RateLimiting.Models.Common;

namespace netCore.RateLimiting.Application.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> Get(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetAll(Expression<Func<T, bool>>? predicate = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
