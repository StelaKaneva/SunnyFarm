namespace SunnyFarm.Services.Products
{
    using System.Collections.Generic;
    using SunnyFarm.Models.Products;
    using SunnyFarm.Services.Products.Models;

    public interface IProductService
    {
        ProductQueryServiceModel All(
            string category,
            string searchTerm,
            ProductSorting sorting,
            int currentPage,
            int productsPerPage);

        ProductDetailsServiceModel Details(int id);

        int Create(
                string name,
                string description,
                string imageUrl,
                int categoryId,
                int size,
                decimal price,
                bool isAvailable);

        bool Edit(
                int id,
                string name,
                string description,
                string imageUrl,
                int categoryId,
                int size,
                decimal price,
                bool isAvailable);

        IEnumerable<string> AllProductCategories();

        IEnumerable<ProductCategoryServiceModel> GetProductCategories();

        bool CategoryExists(int categoryId);
    }
}
