using System.ComponentModel.DataAnnotations;

namespace ShopAPI.Models{

    public class Product{
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(40)]
        public string? Category { get; set; }

        [Required]
        [Range(double.Epsilon, double.MaxValue)]
        public double Price { get; set; }
    }
}