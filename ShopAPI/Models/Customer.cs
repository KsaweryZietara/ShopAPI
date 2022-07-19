using System.ComponentModel.DataAnnotations;

namespace ShopAPI.Models{

    public class Customer{
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string? Name { get; set; }

        [Required]
        public int Tier { get; set; }
    }
}