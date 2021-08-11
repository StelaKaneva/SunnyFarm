namespace SunnyFarm.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using SunnyFarm.Data;
    using SunnyFarm.Data.Models;
    using SunnyFarm.Models.Products;

    public class ProductsController : Controller
    {
        private readonly SunnyFarmDbContext data;

        public ProductsController(SunnyFarmDbContext data)
        {
            this.data = data;
        }

        public IActionResult All([FromQuery]AllProductsQueryModel query)
        {
            var productsQuery = this.data.Products.AsQueryable(); // Взима заявката към базата за продуктите

            if (!string.IsNullOrWhiteSpace(query.Category))
            {
                productsQuery = productsQuery.Where(
                    c => c.Category.Name == query.Category);
            }

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                productsQuery = productsQuery.Where(
                    p => p.Name.ToLower().Contains(query.SearchTerm.ToLower()) ||
                    p.Description.ToLower().Contains(query.SearchTerm.ToLower()) ||
                    p.Category.Name.ToLower().Contains(query.SearchTerm.ToLower()));
            }

            productsQuery = query.Sorting switch
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
                .Skip((query.CurrentPage - 1) * AllProductsQueryModel.ProductsPerPage)
                .Take(AllProductsQueryModel.ProductsPerPage)
                .Select(p => new ProductListingViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    Size = p.Size,
                    Category = p.Category.Name
                })
                .ToList();

            var productCategories = this.data.Categories.Select(c => c.Name).ToList();

            query.Categories = productCategories;
            query.Products = products;
            query.TotalProducts = totalProducts;

            return View(query);
        }

        public IActionResult Add() => View(new AddProductFormModel
        {
            Categories = this.GetProductCategories()
        });


        [HttpPost]
        public IActionResult Add(AddProductFormModel product)
        {
            if (!this.data.Categories.Any(c => c.Id == product.CategoryId))
            {
                this.ModelState.AddModelError(nameof(product.CategoryId), "Category does not exist.");
            }
            
            if (!ModelState.IsValid)
            {
                product.Categories = this.GetProductCategories();
                
                return View(product);
            }

            var productData = new Product 
            {
                Name = product.Name,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                CategoryId = product.CategoryId,
                Size = product.Size,
                Price = product.Price,
                IsAvailable = true
            };

            this.data.Products.Add(productData);
            this.data.SaveChanges();

            return RedirectToAction(nameof(All));
        }

        private IEnumerable<ProductCategoryViewModel> GetProductCategories()
            => this.data
                .Categories
                .Select(c => new ProductCategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();
    }
}
