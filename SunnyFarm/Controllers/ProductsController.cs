namespace SunnyFarm.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SunnyFarm.Models.Products;
    using SunnyFarm.Services.Products;

    public class ProductsController : Controller
    {
        private readonly IProductService products;

        public ProductsController(IProductService products)
        {
            this.products = products;
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

        [Authorize(Roles = WebConstants.AdministratorRoleName)]
        public IActionResult Add() => View(new ProductFormModel
        {
            Categories = this.products.GetProductCategories()
        });


        [HttpPost]
        [Authorize(Roles = WebConstants.AdministratorRoleName)]
        public IActionResult Add(ProductFormModel product)
        {
            if (!this.products.CategoryExists(product.CategoryId))
            {
                this.ModelState.AddModelError(nameof(product.CategoryId), "Category does not exist.");
            }
            
            if (!ModelState.IsValid)
            {
                product.Categories = this.products.GetProductCategories();
                
                return View(product);
            }

            this.products.Create(
                product.Name,
                product.Description,
                product.ImageUrl,
                product.CategoryId,
                product.Size,
                product.Price,
                product.IsAvailable);

            return RedirectToAction(nameof(All));
        }

        [Authorize(Roles = WebConstants.AdministratorRoleName)]
        public IActionResult Edit(int id)
        {
            var product = this.products.Details(id);

            return View(new ProductFormModel
            {
                Name = product.Name,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Size = product.Size,
                Price = product.Price,
                IsAvailable = product.IsAvailable,
                CategoryId = product.CategoryId,
                Categories = this.products.GetProductCategories()
            });
        }

        [Authorize(Roles = WebConstants.AdministratorRoleName)]
        [HttpPost]
        public IActionResult Edit(int id, ProductFormModel product)
        {
            if (!this.products.CategoryExists(product.CategoryId))
            {
                this.ModelState.AddModelError(nameof(product.CategoryId), "Category does not exist.");
            }

            if (!ModelState.IsValid)
            {
                product.Categories = this.products.GetProductCategories();

                return View(product);
            }

            var productIsEdited = this.products.Edit(
                id,
                product.Name,
                product.Description,
                product.ImageUrl,
                product.CategoryId,
                product.Size,
                product.Price,
                product.IsAvailable);

            if (!productIsEdited)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }
    }
}
