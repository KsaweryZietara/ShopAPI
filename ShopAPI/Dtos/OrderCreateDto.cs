using System.ComponentModel.DataAnnotations;
using ShopAPI.Models;

namespace ShopAPI.Dtos{

    public class OrderCreateDto{
        [Required]
        [MaxLength(40)]
        public string? Status { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        public DateTime DelivertyDate { get; set; }

        [Required]
        public List<Product>? Products { get; set; }

        [Required]
        public Customer? Customer { get; set; }
    }
}