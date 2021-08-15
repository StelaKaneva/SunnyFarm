namespace SunnyFarm.Controllers.Api
{
    using System.Collections;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using SunnyFarm.Data;

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
        public IEnumerable GetProducts()
        {
            return this.data.Products.ToList();
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
