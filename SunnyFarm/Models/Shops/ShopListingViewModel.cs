namespace SunnyFarm.Models.Shops
{
    public class ShopListingViewModel
    {
        public int Id { get; init; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string WorkingHours { get; set; }

        public string ImageUrl { get; set; }
    }
}
