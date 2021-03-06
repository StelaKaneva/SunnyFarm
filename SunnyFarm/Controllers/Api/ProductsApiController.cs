namespace SunnyFarm.Controllers.Api
{ 
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using SunnyFarm.Data;
    using SunnyFarm.Data.Models;

    [ApiController]
    [Route("api/products")]
    public class ProductsApiController : ControllerBase
    {
        private readonly SunnyFarmDbContext data;

        public ProductsApiController(SunnyFarmDbContext data)
        {
            this.data = data;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var products = this.data.Products.ToList();

            if (!products.Any())
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetDetails(int id)
        {
            var product = this.data.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}
