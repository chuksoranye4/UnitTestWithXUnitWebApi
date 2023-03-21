using Moq;
using UnitTestWithXUnitWebApi.Controllers;
using UnitTestWithXUnitWebApi.Models;
using UnitTestWithXUnitWebApi.Services;

namespace TestProject
{
    public class UnitTestController
    {
        private readonly Mock<IProductService> _productService;

        public UnitTestController()
        {
            _productService = new Mock<IProductService>();
        }

        [Fact]
        public void GetProductList_ProductList()
        {
            //arrange
            var productlist = GetProductData();
            _productService.Setup(p => p.GetProductList()).Returns(productlist);
            var productController = new ProductController(_productService.Object);

            //act
            var productResult = productController.ProductList();

            //assert
            Assert.NotNull(productlist);
            Assert.Equal(GetProductData().Count(), productlist.Count());
            Assert.Equal(GetProductData().ToString(), productlist.ToString());
            Assert.True(productlist.Equals(productResult));
        }

        [Fact]
        public void GetProductById_Product()
        {
            //arrange(set up)
            var productList = GetProductData();
            _productService.Setup(x => x.GetProductById(2)).Returns(productList[1]);
            var productControllerr = new ProductController(_productService.Object);

            //act Map api calls
            var productResult = productControllerr.GetProductById(2);

            //assert check output result

            Assert.NotNull(productResult);
            Assert.Equal(productList[1].Id, productResult.Id);
            Assert.True(productList[1].Id == productResult.Id);
        }

        [Theory]
        [InlineData("IPhone")]
        public void CheckProductExistOrNotByProductName_Product(string productName)
        {
            //arraane
            var productList = GetProductData();
            _productService.Setup(p => p.GetProductList()).Returns(productList);
            var productController = new ProductController(_productService.Object);

            //act
            var productResult = productController.ProductList();
            var expectedProductName = productResult.ToList()[0].ProductName;

            //assert
            Assert.Equal(productName, expectedProductName);
        }

        [Fact]
        public void AddProduct_Product()
        {
            //arrange
            var productList = GetProductData();
            _productService.Setup(p => p.AddProduct(productList[2])).Returns(productList[2]);
            var productController = new ProductController(_productService.Object);

            //act
            var productResult = productController.AddProduct(productList[2]);

            //result
            Assert.NotNull(productResult);
            Assert.Equal(productList[2].Id, productResult.Id);
            Assert.True(productList[2].Id == productResult.Id);
        }

        private List<Product> GetProductData()
        {
            List<Product> productData = new List<Product>
            {
                 new Product
                {
                    Id = 1,
                    ProductName = "IPhone",
                    ProductDescription = "IPhone 12",
                    ProductPrice = 55000,
                    ProductStock = 10
                },
                 new Product
                {
                     Id = 2,
                    ProductName = "Laptop",
                    ProductDescription = "HP Pavilion",
                    ProductPrice = 100000,
                    ProductStock = 20
                },
                 new Product
                {
                    Id = 3,
                    ProductName = "TV",
                    ProductDescription = "Samsung Smart TV",
                    ProductPrice = 35000,
                    ProductStock = 30
                },
            };
            return productData;
        }
    }
}