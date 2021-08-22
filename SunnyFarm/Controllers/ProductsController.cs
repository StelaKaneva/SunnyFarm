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

        

        
    }
}
