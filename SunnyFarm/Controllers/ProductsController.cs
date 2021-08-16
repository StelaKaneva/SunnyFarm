namespace SunnyFarm.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SunnyFarm.Data;
    using SunnyFarm.Data.Models;
    using SunnyFarm.Models.Products;
    using SunnyFarm.Services.Products;

    public class ProductsController : Controller
    {
        private readonly IProductService products;
        private readonly SunnyFarmDbContext data;

        public ProductsController(IProductService products, SunnyFarmDbContext data)
        {
            this.products = products;
            this.data = data;
        }

        public IActionResult All([FromQuery]AllProductsQueryModel query)
        {
            var queryResult = this.products.All(query.Category, query.SearchTerm, query.Sorting, query.CurrentPage, AllProductsQueryModel.ProductsPerPage);

            var productCategories = this.products.AllProductCategories();

            query.TotalProducts = queryResult.TotalProducts;
            query.Products = queryResult.Products;
            query.Categories = productCategories;

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
                IsAvailable = product.IsAvailable
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
