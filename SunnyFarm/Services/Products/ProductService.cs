namespace SunnyFarm.Services.Products
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using SunnyFarm.Data;
    using SunnyFarm.Data.Models;
    using SunnyFarm.Models.Products;
    using SunnyFarm.Services.Products.Models;

    public class ProductService : IProductService
    {
        private readonly SunnyFarmDbContext data;
        private readonly IConfigurationProvider mapper;

        public ProductService(
            SunnyFarmDbContext data,
            IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper.ConfigurationProvider;
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

        public ProductDetailsServiceModel Details(int id)
            => this.data
            .Products
            .Where(p => p.Id == id)
            .ProjectTo<ProductDetailsServiceModel>(this.mapper)
            .FirstOrDefault();

        public int Create(string name, string description, string imageUrl, int categoryId, int size, decimal price, bool isAvailable)
        {
            var productData = new Product
            {
                Name = name,
                Description = description,
                ImageUrl = imageUrl,
                CategoryId = categoryId,
                Size = size,
                Price = price,
                IsAvailable = isAvailable
            };

            this.data.Products.Add(productData);
            this.data.SaveChanges();

            return productData.Id;
        }

        public bool Edit(int id, string name, string description, string imageUrl, int categoryId, int size, decimal price, bool isAvailable)
        {
            var productData = this.data.Products.Find(id);

            if (productData == null)
            {
                return false;
            }

            productData.Name = name;
            productData.Description = description;
            productData.ImageUrl = imageUrl;
            productData.CategoryId = categoryId;
            productData.Size = size;
            productData.Price = price;
            productData.IsAvailable = isAvailable;

            this.data.SaveChanges();

            return true;
        }

        public IEnumerable<string> AllProductCategories()
            => this.data.Categories.Select(c => c.Name).ToList();

        public IEnumerable<ProductCategoryServiceModel> GetProductCategories()
            => this.data
                .Categories
                .Select(c => new ProductCategoryServiceModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();

        public bool CategoryExists(int categoryId)
            => this.data
            .Categories
            .Any(c => c.Id == categoryId);
    }
}
