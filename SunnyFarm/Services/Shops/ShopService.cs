namespace SunnyFarm.Services.Shops
{
    using System.Linq;
    using SunnyFarm.Data;

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
    }
}
