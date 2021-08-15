namespace SunnyFarm.Models.Products
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Product;

    public class AddProductFormModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(
            int.MaxValue, 
            MinimumLength = DescriptionMinLength,
            ErrorMessage = "The field Description must be a string with a minimum length of {2}.")]
        public string Description { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        [Range(SizeMinValue, SizeMaxValue)]
        public int Size { get; set; }

        [Range(PriceMinValue, PriceMaxValue)]
        public decimal Price { get; set; }

        public bool IsAvailable { get; set; } = true;

        public int CategoryId { get; set; } // CategoryId, което user-ът изпраща

        public IEnumerable<ProductCategoryViewModel> Categories { get; set; } // Категориите, които искам да визуализирам на View-то
    }
}
