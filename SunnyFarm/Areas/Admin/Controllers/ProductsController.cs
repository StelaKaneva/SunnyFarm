namespace SunnyFarm.Areas.Admin.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using SunnyFarm.Models.Products;
    using SunnyFarm.Services.Products;

    public class ProductsController : AdminController
    {
        private readonly IProductService products;
        private readonly IMapper mapper;

        public ProductsController(
            IProductService products,
            IMapper mapper)
        {
            this.products = products;
            this.mapper = mapper;
        }

        public IActionResult Add() => View(new ProductFormModel
        {
            Categories = this.products.GetProductCategories()
        });


        [HttpPost]
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

            var productId = this.products.Create(
                product.Name,
                product.Description,
                product.ImageUrl,
                product.CategoryId,
                product.Size,
                product.Price,
                product.IsAvailable);

            return RedirectToAction("Details", "Products", new { area="", id = productId });
        }

        public IActionResult Edit(int id)
        {
            var product = this.products.Details(id);

            var productForm = this.mapper.Map<ProductFormModel>(product);
            productForm.Categories = this.products.GetProductCategories();

            return View(productForm);
        }

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

            return RedirectToAction("Details", "Products", new { area = "", id = id });
        }
    }
}
