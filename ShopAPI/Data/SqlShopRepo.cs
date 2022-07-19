using Microsoft.EntityFrameworkCore;
using ShopAPI.Models;

namespace ShopAPI.Data{

    public class SqlShopRepo : IShopRepo{   

        private readonly ShopDbContext _context;

        public SqlShopRepo(ShopDbContext context){
            _context = context;
        }

        public async Task CreateCustomerAsync(Customer customer){
            if(customer == null){
                throw new ArgumentNullException(nameof(customer));
            }

            await _context.AddAsync(customer);
        }

        public async Task CreateOrderAsync(Order order){
            if(order == null){
                throw new ArgumentNullException(nameof(order));
            }

            await _context.AddAsync(order);
        }

        public async Task CreateProductAsync(Product product){
           if(product == null){
                throw new ArgumentNullException(nameof(product));
            }

            await _context.AddAsync(product);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync(){
            return await _context.Customers.ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync(){
            return await _context.Orders.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(){
            return await _context.Products.ToListAsync();
        }

        public async Task SaveChangesAsync(){
            await _context.SaveChangesAsync();
        }
    }
}