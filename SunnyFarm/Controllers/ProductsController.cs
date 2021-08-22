namespace SunnyFarm.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SunnyFarm.Models.Products;
    using SunnyFarm.Services.Products;

    using static Areas.Admin.AdminConstants;

    public class ProductsController : Controller
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

        public IActionResult All([FromQuery]AllProductsQueryModel query)
        {
            var queryResult = this.products.All(query.Category, query.SearchTerm, query.Sorting, query.CurrentPage, AllProductsQueryModel.ProductsPerPage);

            var productCategories = this.products.AllProductCategories();

            query.TotalProducts = queryResult.TotalProducts;
            query.Products = queryResult.Products;
            query.Categories = productCategories;

            return View(query);
        }

        public IActionResult Details(int id)
        {
            var product = products.Details(id);

            return View(product);
        }

        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult Add() => View(new ProductFormModel
        {
            Categories = this.products.GetProductCategories()
        });


        [HttpPost]
        [Authorize(Roles = AdministratorRoleName)]
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

        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult Edit(int id)
        {
            var product = this.products.Details(id);

            var productForm = this.mapper.Map<ProductFormModel>(product);
            productForm.Categories = this.products.GetProductCategories();

            return View(productForm);
        }

        [Authorize(Roles = AdministratorRoleName)]
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
