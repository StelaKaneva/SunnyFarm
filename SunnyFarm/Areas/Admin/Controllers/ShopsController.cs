namespace SunnyFarm.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SunnyFarm.Models.Shops;
    using SunnyFarm.Services.Shops;

    public class ShopsController : AdminController
    {
        private readonly IShopService shops;

        public ShopsController(IShopService shops)
        {
            this.shops = shops;
        }

        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(ShopFormModel shop)
        {
            if (!ModelState.IsValid)
            {
                return View(shop);
            }

            this.shops.Create(
                shop.Name,
                shop.Address,
                shop.Phone,
                shop.WorkingHours,
                shop.ImageUrl);

            return RedirectToAction("All", "Shops", new { area = "" });
        }

        public IActionResult Edit(int id)
        {
            var shop = this.shops.Details(id);

            return View(new ShopFormModel
            {
                Name = shop.Name,
                Address = shop.Address,
                Phone = shop.Phone,
                WorkingHours = shop.WorkingHours,
                ImageUrl = shop.ImageUrl
            });
        }

        [HttpPost]
        public IActionResult Edit(int id, ShopFormModel shop)
        {
            if (!ModelState.IsValid)
            {
                return View(shop);
            }

            var shopIsEdited = this.shops.Edit(
                id,
                shop.Name,
                shop.Address,
                shop.Phone,
                shop.WorkingHours,
                shop.ImageUrl);

            if (!shopIsEdited)
            {
                return BadRequest();
            }

            return RedirectToAction("All", "Shops", new { area = "" });
        }
    }
}
