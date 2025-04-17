using Microsoft.EntityFrameworkCore;
using SpecificationPatternDemo.Repository.Specifications;
using System.Linq.Expressions;

namespace SpecificationPatternDemo.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class //TEntity : Entity, IAggregateRoot
    {
        protected readonly AdventureWorksDbContext _context;
        internal DbSet<TEntity> _set;

        public GenericRepository(AdventureWorksDbContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
        }

        public async Task<IAsyncEnumerable<TEntity>> Specify(ISpecification<TEntity> spec)
        {
            var includes = spec.IncludeExpressions.Aggregate(_set.AsQueryable(),
                            (current, include) => current.Include(include));

            return includes
            .Where(spec.Criteria)
            .AsAsyncEnumerable();
        }

        //can be optional
        public IEnumerable<TEntity> SpecifyWithPagination(ISpecification<TEntity> spec, int pageSize = 10, int pageIndex = 0)
        {
            var includes = spec.IncludeExpressions.Aggregate(_set.AsQueryable(),
                            (current, include) => current.Include(include));

            return includes
            .Where(spec.Criteria).Skip(pageSize * pageIndex).Take(pageSize)
            .AsEnumerable();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _set.AddAsync(entity);
            return entity;
        }

        public async Task<TEntity[]> AddRangeAsync(TEntity[] entity)
        {
            await _set.AddRangeAsync(entity);
            return entity;
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, string include)
        {
            return await _set.Include(include).AnyAsync(predicate);
        }

        public Task DeleteAsync(TEntity entity)
        {
            _set.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate, params string[] includes)
        {
            var data = await _set.FirstOrDefaultAsync(predicate);
            if (includes.Any())
            {
                data = Include(includes).FirstOrDefault();
            }
            return data;
        }

        public async Task<IReadOnlyList<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate = null, params string[] includes)
        {

            var data = predicate == null ? _set : _set.Where(predicate);
            if (includes.Any())
            {
                data = Include(includes).AsQueryable();
            }
            return await data.ToListAsync();
        }

        IEnumerable<TEntity> Include(params string[] includes)
        {
            IEnumerable<TEntity> query = null;
            foreach (var include in includes)
            {
                query = _set.Include(include);
            }

            return query ?? _set;
        }


        public async Task<TEntity> GetByIdAsync(int Id, params string[] includes)
        {
            var data = await _set.FindAsync(Id);
            if (includes.Any())
            {
                data = Include(includes).FirstOrDefault();
            }
            return data;
        }

        public Task UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
