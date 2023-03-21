using UnitTestWithXUnitWebApi.Data;
using UnitTestWithXUnitWebApi.Models;

namespace UnitTestWithXUnitWebApi.Services
{
    public class ProductService : IProductService
    {
        private readonly DbContextClass _dbContext;

        public ProductService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public Product AddProduct(Product product)
        {
            var result = _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public bool DeleteProduct(int Id)
        {
            var data = _dbContext.Products.Where(p => p.Id == Id).FirstOrDefault();
            var result = _dbContext.Remove(data!);
            _dbContext.SaveChanges();
            return result != null ? true : false;
        }

        public Product GetProductById(int id)
        {
            return _dbContext.Products.Where(p => p.Id == id).FirstOrDefault()!;
        }

        public IEnumerable<Product> GetProductList()
        {
            return _dbContext.Products.ToList();
        }

        public Product UpdateProduct(Product product)
        {
            var result = _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }
    }
}
