using ShopAPI.Models;

namespace ShopAPI.Data{
    
    public interface IShopRepo{
        Task SaveChangesAsync();
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task CreateCustomerAsync(Customer customer);
        Task CreateOrderAsync(Order order);
        Task CreateProductAsync(Product product);
    }
}