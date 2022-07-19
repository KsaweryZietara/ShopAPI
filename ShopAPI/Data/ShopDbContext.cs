using Microsoft.EntityFrameworkCore;
using ShopAPI.Models;

namespace ShopAPI.Data{

    public class ShopDbContext : DbContext{
        public DbSet<Customer> Customers => Set<Customer>();

        public DbSet<Order> Orders => Set<Order>();

        public DbSet<Product> Products => Set<Product>();

        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options){
        }
    }
}