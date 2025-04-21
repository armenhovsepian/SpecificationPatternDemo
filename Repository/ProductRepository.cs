using Microsoft.EntityFrameworkCore;
using SpecificationPatternDemo.Dtos;
using SpecificationPatternDemo.Mappings;
using SpecificationPatternDemo.Repository.Models;
using SpecificationPatternDemo.Repository.Specifications;

namespace SpecificationPatternDemo.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AdventureWorksDbContext context) : base(context)
        {
        }

        public ProductRepository() : this(new AdventureWorksDbContext())
        {

        }

        public async Task<IEnumerable<Product>> GetProducts(ISpecification<Product> specification, int pageSize = 10, int pageIndex = 0)
        {
            var products = await ApplySpecification(specification)
                .Skip(pageSize * pageIndex).Take(pageSize)
                .ToListAsync();

            return products;
        }

        public async Task<Product> GetProduct(ISpecification<Product> specification)
        {
            var product = await ApplySpecification(specification)
                .FirstOrDefaultAsync();

            return product;
        }

        private IQueryable<Product> ApplySpecification(ISpecification<Product> specification)
        {
            return SpecificationEvaluator<Product>.GetQuery(_set, specification);
        }

        public async Task<ProductDto> GetProduct(IExtendedSpecification<Product, ProductDto> specification)
        {
            var query = _set.AsQueryable();

            if (specification.Criteria is not null)
            {
                query = query.Where(specification.Criteria);
            }

            if (specification.IncludeExpressions is not null)
            {
                foreach (var expression in specification.IncludeExpressions)
                {
                    query = query.Include(expression);
                }
            }

            if (specification.OrderByExpression is not null)
            {
                query = query.OrderBy(specification.OrderByExpression);
            }
            else if (specification.OrderByDescendingExpression is not null)
            {
                query = query.OrderByDescending(specification.OrderByDescendingExpression);
            }

            if (specification.Projection is not null)
            {
                var result = await query.Select(specification.Projection).FirstOrDefaultAsync();
                return result;
            }
            else
            {
                var product = await query.FirstOrDefaultAsync();
                return product?.ProductToDto();
            }
        }
    }
}
