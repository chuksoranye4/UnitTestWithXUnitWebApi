using Microsoft.AspNetCore.Mvc;
using UnitTestWithXUnitWebApi.Models;
using UnitTestWithXUnitWebApi.Services;

namespace UnitTestWithXUnitWebApi.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("productlist")]
        public IEnumerable<Product> ProductList()
        {
            return _productService.GetProductList();
        }
        [HttpGet("getproductbyid")]
        public Product GetProductById(int Id)
        {
            return _productService.GetProductById(Id);
        }
        [HttpPut("updateproduct")]
        public Product UpdateProduct(Product product)
        {
            return _productService.UpdateProduct(product);
        }
        [HttpPost("addproduct")]
        public Product AddProduct(Product product)
        {
            return _productService.AddProduct(product);
        }
        [HttpDelete("deleteproduct")]
        public bool DeleteProduct(int Id)
        {
            return _productService.DeleteProduct(Id);
        }
    }
}
