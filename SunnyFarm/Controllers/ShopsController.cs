namespace SunnyFarm.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SunnyFarm.Models.Shops;
    using SunnyFarm.Services.Shops;

    using static Areas.Admin.AdminConstants;

    public class ShopsController : Controller
    {
        private readonly IShopService shops;

        public ShopsController(IShopService shops)
        {
            this.shops = shops;
        }

        public IActionResult All([FromQuery] AllShopsQueryModel query)
        {
            var queryResult = this.shops.All(query.CurrentPage, AllShopsQueryModel.ProductsPerPage);

            query.Shops = queryResult.Shops;
            query.TotalShops = queryResult.TotalShops;

            return View(query);
        }

        
    }
}
