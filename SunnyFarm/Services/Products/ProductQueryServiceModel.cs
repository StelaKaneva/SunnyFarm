using System.Collections.Generic;

namespace SunnyFarm.Services.Products
{
    public class ProductQueryServiceModel
    {
        public int CurrentPage { get; init; }

        public int ProductsPerPage { get; init; }

        public int TotalProducts { get; init; }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<ProductServiceModel> Products { get; init; }
    }
}
