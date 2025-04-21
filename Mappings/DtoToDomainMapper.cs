using SpecificationPatternDemo.Dtos;
using SpecificationPatternDemo.Repository.Models;

namespace SpecificationPatternDemo.Mappings
{
    public static class DtoToDomainMapper
    {
        public static Product ProductDtoToProduct(this ProductDto productDto)
        {
            return new Product
            {
                ProductId = productDto.Id,
                Name = productDto.Name,
                ProductNumber = productDto.Sku,
                ProductCategory = productDto.CategoryDto?.CategoryDtoToCategory()
            };
        }

        public static IEnumerable<Product> ProductDtosToProducts(this IEnumerable<ProductDto> productDtos)
        {
            return productDtos.Select(p => p.ProductDtoToProduct());
        }

        public static ProductCategory CategoryDtoToCategory(this CategoryDto categoryDto)
        {
            return new ProductCategory
            {
                ProductCategoryId = categoryDto.Id,
                Name = categoryDto.Name
            };
        }
    }
}
