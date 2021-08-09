namespace SunnyFarm.Models.Products
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class AddProductFormModel
    {
        [Required]
        [StringLength(ProductNameMaxLength, MinimumLength = ProductNameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(
            int.MaxValue, 
            MinimumLength = ProductDescriptionMinLength,
            ErrorMessage = "The field Description must be a string with a minimum length of {2}.")]
        public string Description { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        [Range(ProductSizeMinValue, ProductSizeMaxValue)]
        public int Size { get; set; }

        [Range(ProductPriceMinValue, ProductPriceMaxValue)]
        public decimal Price { get; set; }

        public int CategoryId { get; set; } // CategoryId, което user-ът изпраща

        public IEnumerable<ProductCategoryViewModel> Categories { get; set; } // Категориите, които искам да визуализирам на View-то
    }
}
