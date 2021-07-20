namespace SunnyFarm.Data.Models
{
    using System.Collections.Generic;

    public class Category
    {
        public Category()
        {
            this.Products = new List<Product>();
        }

        public int Id { get; init; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
