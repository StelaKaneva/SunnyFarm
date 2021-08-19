namespace SunnyFarm.Services.Shops
{
    public interface IShopService
    {
        ShopQueryServiceModel All(
            int currentPage,
            int productsPerPage);

        ShopServiceModel Details(int id);

        int Create(
            string name,
            string address,
            string phone,
            string workingHours,
            string imageUrl);

        bool Edit(
                int id,
                string name,
                string address,
                string phone,
                string workingHours,
                string imageUrl);

    }
}
