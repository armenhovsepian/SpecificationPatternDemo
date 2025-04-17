using Microsoft.EntityFrameworkCore;


namespace SpecificationPatternDemo.Repository.Specifications
{
    public class SpecificationEvaluator<TEntity> where TEntity : class // Ensure TEntity is a reference type
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQueryable, ISpecification<TEntity> specification)
        {
            IQueryable<TEntity> query = inputQueryable;

            if (specification.Criteria is not null)
            {
                query = query.Where(specification.Criteria);
            }

            if (specification.IncludeExpressions is not null)
            {
                foreach (var expression in specification.IncludeExpressions)
                {
                    query = query.Include(expression); // Fix: Ensure Include works with TEntity constrained to class
                }

                // option 2:
                //query = specification.IncludeExpressions.Aggregate(query, (current, include) => current.Include(include));
            }

            if (specification.OrderByExpression is not null)
            {
                query = query.OrderBy(specification.OrderByExpression);
            }
            else if (specification.OrderByDescendingExpression is not null)
            {
                query = query.OrderByDescending(specification.OrderByDescendingExpression);
            }

            return query;
        }
    }
}
