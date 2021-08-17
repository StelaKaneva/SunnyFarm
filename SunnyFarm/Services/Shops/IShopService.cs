namespace SunnyFarm.Services.Shops
{
    public interface IShopService
    {
        ShopQueryServiceModel All(
            int currentPage,
            int productsPerPage);
    }
}
