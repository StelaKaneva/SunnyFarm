namespace SunnyFarm.Services.Products
{
    public class ProductServiceModel
    {
        public int Id { get; init; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public int Size { get; set; }

        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }

        public string Category { get; set; }
    }
}
