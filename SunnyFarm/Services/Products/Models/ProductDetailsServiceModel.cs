namespace SunnyFarm.Services.Products.Models
{
    public class ProductDetailsServiceModel : ProductServiceModel
    {
        public string Description { get; set; }

        public int CategoryId { get; set; }
    }
}
