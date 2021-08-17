namespace SunnyFarm.Controllers
{
    using System.Linq;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SunnyFarm.Data;
    using SunnyFarm.Data.Models;
    using SunnyFarm.Models.Shops;
    using SunnyFarm.Services.Shops;

    public class ShopsController : Controller
    {
        private readonly IShopService shops;
        private readonly SunnyFarmDbContext data;

        public ShopsController(IShopService shops, SunnyFarmDbContext data)
        {
            this.shops = shops;
            this.data = data;
        }

        public IActionResult All([FromQuery] AllShopsQueryModel query)
        {
            var queryResult = this.shops.All(query.CurrentPage, AllShopsQueryModel.ProductsPerPage);

            query.Shops = queryResult.Shops;
            query.TotalShops = queryResult.TotalShops;

            return View(query);
        }

        [Authorize]
        public IActionResult Add() => View();

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddShopFormModel shop)
        {
            if (!ModelState.IsValid)
            {
                return View(shop);
            }

            var shopData = new Shop
            {
                Name = shop.Name,
                Phone = shop.Phone,
                Address = shop.Address,
                WorkingHours = shop.WorkingHours,
                ImageUrl = shop.ImageUrl
            };

            this.data.Shops.Add(shopData);
            this.data.SaveChanges();

            return RedirectToAction(nameof(All));
        }

    }
}
