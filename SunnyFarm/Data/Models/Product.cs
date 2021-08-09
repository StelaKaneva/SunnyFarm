namespace SunnyFarm.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;

    public class Product
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(ProductNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int Size { get; set; }

        public decimal Price { get; set; }
    }
}
