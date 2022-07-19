using System.ComponentModel.DataAnnotations;

namespace ShopAPI.Dtos{

    public class CustomerCreateDto{
        [Required]
        [MaxLength(40)]
        public string? Name { get; set; }

        [Required]
        public int Tier { get; set; }
    }
}