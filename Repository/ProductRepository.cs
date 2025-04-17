using Microsoft.EntityFrameworkCore;
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


    }
}
