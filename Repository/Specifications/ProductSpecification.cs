using SpecificationPatternDemo.Repository.Models;

namespace SpecificationPatternDemo.Repository.Specifications
{
    public class ProductSpecification : Specification<Product>
    {
        public ProductSpecification()
        {
        }


        public ProductSpecification(int productId) : base(product => product.ProductId == productId)
        {
            //AddInclude(product => product.ProductCategory);
        }

        //public ProductSpecification IncludeReference(Expression<Func<Product, object>> expression)
        //{
        //    AddInclude(expression);
        //    return this;
        //}
    }
}
