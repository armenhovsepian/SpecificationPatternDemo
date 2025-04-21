using System.Linq.Expressions;

namespace SpecificationPatternDemo.Repository.Specifications
{
    public interface IExtendedSpecification<TEntity, TResult>
    {
        Expression<Func<TEntity, bool>>? Criteria { get; }
        List<Expression<Func<TEntity, object>>> IncludeExpressions { get; set; }
        Expression<Func<TEntity, object>>? OrderByDescendingExpression { get; set; }
        Expression<Func<TEntity, object>>? OrderByExpression { get; set; }
        Expression<Func<TEntity, TResult>>? Projection { get; }
    }
}