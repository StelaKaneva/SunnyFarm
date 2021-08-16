namespace SunnyFarm.Services.Products
{
    using System.Collections.Generic;
    using SunnyFarm.Models.Products;

    public interface IProductService
    {
        ProductQueryServiceModel All(
            string category,
            string searchTerm,
            ProductSorting sorting,
            int currentPage,
            int productsPerPage);

        IEnumerable<string> AllProductCategories();
    }
}
