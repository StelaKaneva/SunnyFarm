namespace SunnyFarm.Services.Products
{
    using System.Collections.Generic;
    using System.Linq;
    using SunnyFarm.Data;
    using SunnyFarm.Models.Products;

    public class ProductService : IProductService
    {
        private readonly SunnyFarmDbContext data;

        public ProductService(SunnyFarmDbContext data)
        {
            this.data = data;
        }

        public ProductQueryServiceModel All(
            string category,
            string searchTerm,
            ProductSorting sorting,
            int currentPage,
            int productsPerPage)
        {
            var productsQuery = this.data.Products.Where(p => p.IsAvailable == true).AsQueryable(); // Взима заявката към базата за продуктите

            if (!string.IsNullOrWhiteSpace(category))
            {
                productsQuery = productsQuery.Where(
                    c => c.Category.Name == category);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                productsQuery = productsQuery.Where(
                    p => p.Name.ToLower().Contains(searchTerm.ToLower()) ||
                    p.Description.ToLower().Contains(searchTerm.ToLower()) ||
                    p.Category.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            productsQuery = sorting switch
            {
                ProductSorting.Category => productsQuery.OrderBy(p => p.CategoryId).ThenByDescending(p => p.Price),
                ProductSorting.PriceAscending => productsQuery.OrderBy(p => p.Price),
                ProductSorting.PriceDescending => productsQuery.OrderByDescending(p => p.Price),
                ProductSorting.SizeAscending => productsQuery.OrderBy(p => p.Size),
                ProductSorting.SizeDescending => productsQuery.OrderByDescending(p => p.Size),
                ProductSorting.DateCreated => productsQuery.OrderByDescending(p => p.Id),
                _ => productsQuery.OrderBy(p => p.CategoryId).ThenByDescending(p => p.Price)
            };

            var totalProducts = productsQuery.Count();

            var products = productsQuery
                .Skip((currentPage - 1) * productsPerPage)
                .Take(productsPerPage)
                .Select(p => new ProductServiceModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    Size = p.Size,
                    IsAvailable = p.IsAvailable,
                    Category = p.Category.Name
                })
                .ToList();

            return new ProductQueryServiceModel
            {
                TotalProducts = totalProducts,
                CurrentPage = currentPage,
                ProductsPerPage = productsPerPage,
                Products = products
            };
        }

        public IEnumerable<string> AllProductCategories()
            => this.data.Categories.Select(c => c.Name).ToList();
    }
}
