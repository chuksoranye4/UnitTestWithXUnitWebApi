using Microsoft.EntityFrameworkCore;
using UnitTestWithXUnitWebApi.Models;

namespace UnitTestWithXUnitWebApi.Data
{
    public class DbContextClass : DbContext
    {
        protected readonly IConfiguration _configuration;

        public DbContextClass(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("ConnStr"));
        }
        public DbSet<Product> Products { get; set; }
    }
}
