namespace SunnyFarm.Services.Shops
{
    using System.Linq;
    using SunnyFarm.Data;
    using SunnyFarm.Data.Models;

    public class ShopService : IShopService
    {
        private readonly SunnyFarmDbContext data;

        public ShopService(SunnyFarmDbContext data)
        {
            this.data = data;
        }

        public ShopQueryServiceModel All(
            int currentPage,
            int productsPerPage)
        {
            var shopsQuery = this.data.Shops.AsQueryable();

            var totalShops = shopsQuery.Count();

            var shops = shopsQuery
                .OrderByDescending(s => s.Id)
                .Skip((currentPage - 1) * productsPerPage)
                .Take(productsPerPage)
                .Select(s => new ShopServiceModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Address = s.Address,
                    Phone = s.Phone,
                    WorkingHours = s.WorkingHours,
                    ImageUrl = s.ImageUrl
                })
                .ToList();

            return new ShopQueryServiceModel
            {
                CurrentPage = currentPage,
                ProductsPerPage = productsPerPage,
                TotalShops = totalShops,
                Shops = shops
            };
        }

        public ShopServiceModel Details(int id)
            => this.data
                .Shops
                .Where(s => s.Id == id)
                .Select(s => new ShopServiceModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Address = s.Address,
                    Phone = s.Phone,
                    WorkingHours = s.WorkingHours,
                    ImageUrl = s.ImageUrl
                })
                .FirstOrDefault();

        public int Create(string name, string address, string phone, string workingHours, string imageUrl)
        {
            var shopData = new Shop
            {
                Name = name,
                Phone = phone,
                Address = address,
                WorkingHours = workingHours,
                ImageUrl = imageUrl,
            };

            this.data.Shops.Add(shopData);
            this.data.SaveChanges();

            return shopData.Id;
        }

        public bool Edit(int id, string name, string address, string phone, string workingHours, string imageUrl)
        {
            var shoptData = this.data.Shops.Find(id);

            if (shoptData == null)
            {
                return false;
            }

            shoptData.Name = name;
            shoptData.Address = address;
            shoptData.Phone = phone;
            shoptData.WorkingHours = workingHours;
            shoptData.ImageUrl = imageUrl;

            this.data.SaveChanges();

            return true;
        }
    }
}
