using SpecificationPatternDemo.Dtos;
using SpecificationPatternDemo.Repository.Models;
using SpecificationPatternDemo.Repository.Specifications;

namespace SpecificationPatternDemo.Repository
{
    public interface IProductRepository
    {
        Task<Product> GetProduct(ISpecification<Product> specification);
        Task<IEnumerable<Product>> GetProducts(ISpecification<Product> specification, int pageSize = 10, int pageIndex = 0);


        Task<ProductDto> GetProduct(IExtendedSpecification<Product, ProductDto> specification);
    }
}