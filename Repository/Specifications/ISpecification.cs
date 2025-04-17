using System.Linq.Expressions;

namespace SpecificationPatternDemo.Repository.Specifications
{
    public interface ISpecification<TEntity>
    {
        Expression<Func<TEntity, bool>>? Criteria { get; }
        List<Expression<Func<TEntity, object>>> IncludeExpressions { get; set; }
        Expression<Func<TEntity, object>>? OrderByDescendingExpression { get; set; }
        Expression<Func<TEntity, object>>? OrderByExpression { get; set; }
    }
}