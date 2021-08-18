namespace SunnyFarm.Services.Products
{
    public class ProductDetailsServiceModel : ProductServiceModel
    {
        public string Description { get; set; }

        public int CategoryId { get; set; }
    }
}
