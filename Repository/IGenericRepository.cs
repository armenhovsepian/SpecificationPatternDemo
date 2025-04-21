using System.Linq.Expressions;

namespace SpecificationPatternDemo.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity[]> AddRangeAsync(TEntity[] entity);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, string include);
        Task DeleteAsync(TEntity entity);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate, params string[] includes);
        Task<IReadOnlyList<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate = null, params string[] includes);
        Task<TEntity> GetByIdAsync(int Id, params string[] includes);
        Task UpdateAsync(TEntity entity);

    }
}