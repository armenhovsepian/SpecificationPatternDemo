using System.Linq.Expressions;

namespace SpecificationPatternDemo.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<T[]> AddRangeAsync(T[] entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, string include);
        Task DeleteAsync(T entity);
        Task<T> Get(Expression<Func<T, bool>> predicate, params string[] includes);
        Task<IReadOnlyList<T>> GetAll(Expression<Func<T, bool>> predicate = null, params string[] includes);
        Task<T> GetByIdAsync(int Id, params string[] includes);
        Task UpdateAsync(T entity);
    }
}