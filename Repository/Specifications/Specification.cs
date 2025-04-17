using System.Linq.Expressions;

namespace SpecificationPatternDemo.Repository.Specifications
{
    public abstract class Specification<TEntity> : ISpecification<TEntity>
    {
        protected Specification()
        {

        }
        protected Specification(Expression<Func<TEntity, bool>> criteria)
        {
            Criteria = criteria;
        }


        public Expression<Func<TEntity, bool>> Criteria { get; }

        public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; set; } = new();

        public Expression<Func<TEntity, object>>? OrderByExpression { get; set; }
        public Expression<Func<TEntity, object>>? OrderByDescendingExpression { get; set; }

        protected void AddInclude(Expression<Func<TEntity, object>> includeExpression)
            => IncludeExpressions.Add(includeExpression);


        protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression)
            => OrderByExpression = orderByExpression;

        protected void AddOrderByDescending(Expression<Func<TEntity, object>> orderByDescendingExpression)
            => OrderByDescendingExpression = orderByDescendingExpression;
    }
}
