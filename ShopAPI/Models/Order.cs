using System;
using System.ComponentModel.DataAnnotations;

namespace ShopAPI.Models{

    public class Order{
        [Key]
        public int Id { get; set; }

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