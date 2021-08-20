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

        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult Add() => View();

        [HttpPost]
        [Authorize(Roles = AdministratorRoleName)]
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

            return RedirectToAction(nameof(All));
        }

        [Authorize(Roles = AdministratorRoleName)]
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

        [Authorize(Roles = AdministratorRoleName)]
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

            return RedirectToAction(nameof(All));
        }
    }
}
