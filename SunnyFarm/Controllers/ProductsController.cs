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
                Price = product.Price
            };

            this.data.Products.Add(productData);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
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
