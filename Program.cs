using SpecificationPatternDemo.Repository;
using SpecificationPatternDemo.Repository.Specifications;

Console.WriteLine("Hello, World!");

var productRepository = new ProductRepository();

var product = await productRepository.GetProduct(new ProductSpecification(productId: 836));

var paginatedProducts = await productRepository.GetProducts(new ProductSpecification(), 10, 1);


// Extended Specification
var productDto = await productRepository.GetProduct(new ExtendedProductSpecification(productId: 836));

Console.WriteLine(product.Name);