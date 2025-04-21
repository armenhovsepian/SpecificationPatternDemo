using SpecificationPatternDemo.Dtos;
using SpecificationPatternDemo.Repository.Models;

namespace SpecificationPatternDemo.Mappings
{
    public static class DomainToDtoMapper
    {
        public static ProductDto ProductToDto(this Product product)
        {
            return new ProductDto
            {
                Id = product.ProductId,
                Name = product.Name,
                Sku = product.ProductNumber,
                Price = product.ListPrice,
                CategoryDto = product.ProductCategory?.CategoryToDto()
            };
        }

        public static IEnumerable<ProductDto> ProductsToDtos(this IEnumerable<Product> products)
        {
            return products.Select(p => p.ProductToDto());
        }

        public static CategoryDto CategoryToDto(this ProductCategory category)
        {
            return new CategoryDto
            {
                Id = category.ProductCategoryId,
                Name = category.Name
            };
        }
    }
}
