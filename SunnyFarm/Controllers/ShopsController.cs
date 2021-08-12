namespace SunnyFarm.Controllers
{
    using System.Linq;
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

        public IActionResult All([FromQuery] AllShopsQueryModel query)
        {
            var shopsQuery = this.data.Shops.AsQueryable();

            var totalShops = shopsQuery.Count();

            var shops = shopsQuery
                .OrderByDescending(s => s.Id)
                .Skip((query.CurrentPage - 1) * AllShopsQueryModel.ProductsPerPage)
                .Take(AllShopsQueryModel.ProductsPerPage)
                .Select(s => new ShopListingViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Address = s.Address,
                    Phone = s.Phone,
                    WorkingHours = s.WorkingHours,
                    ImageUrl = s.ImageUrl
                })
                .ToList();

            query.Shops = shops;
            query.TotalShops = totalShops;

            return View(query);
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
