namespace SunnyFarm.Services.Shops
{
    using System.Collections.Generic;

    public class ShopQueryServiceModel
    {
        public int ShopsPerPage { get; init; }

        public int CurrentPage { get; init; }

        public int TotalShops { get; set; }

        public IEnumerable<ShopServiceModel> Shops { get; set; }
    }
}
