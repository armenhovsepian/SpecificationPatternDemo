using SpecificationPatternDemo.Dtos;
using SpecificationPatternDemo.Mappings;
using SpecificationPatternDemo.Repository.Models;

namespace SpecificationPatternDemo.Repository.Specifications
{
    public class ExtendedProductSpecification : ExtendedSpecification<Product, ProductDto>
    {
        public ExtendedProductSpecification()
        {
        }


        public ExtendedProductSpecification(int productId) : base(product => product.ProductId == productId)
        {
            IncludeExpressions.Add(product => product.ProductCategory);
            Projection = p => p.ProductToDto();
        }
    }
}
