namespace SunnyFarm.Controllers.Api
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using SunnyFarm.Data;
    using SunnyFarm.Data.Models;

    [ApiController]
    [Route("api/shops")]
    public class ShopsApiController : ControllerBase
    {
        private readonly SunnyFarmDbContext data;

        public ShopsApiController(SunnyFarmDbContext data)
        {
            this.data = data;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Shop>> GetShops()
        {
            var shops = this.data.Shops.ToList();

            if (!shops.Any())
            {
                return NotFound();
            }

            return Ok(shops);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetDetails(int id)
        {
            var shop = this.data.Shops.Find(id);

            if (shop == null)
            {
                return NotFound();
            }

            return Ok(shop);
        }
    }
}
