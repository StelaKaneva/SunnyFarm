namespace SunnyFarm.Models.Products
{
    using System.Collections.Generic;

    public class AllProductsQueryModel
    {
        public string Category { get; init; }

        public IEnumerable<string> Categories { get; init; }

        public string SearchTerm { get; init; }

        public ProductSorting Sorting { get; init; }

        public IEnumerable<ProductListingViewModel> Products { get; init; }
    }
}
