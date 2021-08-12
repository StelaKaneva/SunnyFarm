namespace SunnyFarm.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SunnyFarm.Data;
    using SunnyFarm.Data.Models;
    using SunnyFarm.Models.Shops;

    public class ShopsController : Controller
    {
        private readonly SunnyFarmDbContext data;

        public ShopsController(SunnyFarmDbContext data)
        {
            this.data = data;
        }

        public IActionResult All()
        {
            return View();
        }

        public IActionResult Add() => View();

        [HttpPost]
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
