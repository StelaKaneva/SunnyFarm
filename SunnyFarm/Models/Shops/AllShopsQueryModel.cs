namespace SunnyFarm.Models.Shops
{
    using SunnyFarm.Services.Shops;
    using System.Collections.Generic;

    public class AllShopsQueryModel
    {
        public const int ProductsPerPage = 3;

        public int CurrentPage { get; init; } = 1;

        public int TotalShops { get; set; }

        public IEnumerable<ShopServiceModel> Shops { get; set; }
    }
}
