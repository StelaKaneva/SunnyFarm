namespace SunnyFarm.Data.Models
{
    using System.Collections.Generic;

    public class PriceSizeCombination
    {
        public PriceSizeCombination()
        {
            this.Products = new List<Product>();
        }

        public int Id { get; init; }

        public int Size { get; set; }

        public decimal Price { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
