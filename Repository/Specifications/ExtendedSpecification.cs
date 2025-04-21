using System.Linq.Expressions;

namespace SpecificationPatternDemo.Repository.Specifications
{
    public abstract class ExtendedSpecification<TEntity, TResult> : IExtendedSpecification<TEntity, TResult>
    {
        protected ExtendedSpecification()
        {

        }

        protected ExtendedSpecification(Expression<Func<TEntity, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<TEntity, bool>> Criteria { get; }

        public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; set; } = new();

        public Expression<Func<TEntity, object>>? OrderByExpression { get; set; }
        public Expression<Func<TEntity, object>>? OrderByDescendingExpression { get; set; }
        public Expression<Func<TEntity, TResult>>? Projection { get; set; }
    }

}
