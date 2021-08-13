namespace SunnyFarm.Models.Shops
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Shop;
    using static Data.DataConstants.PersonalData;

    public class AddShopFormModel
    {
        [Required]
        [StringLength(ShopNameMaxLength, MinimumLength = ShopNameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
        public string Address { get; set; }

        [Required]
        [StringLength(PhoneMaxLength, MinimumLength = PhoneMinLength)]
        public string Phone { get; set; }

        [Required]
        [StringLength(WorkingHoursMaxLength, MinimumLength = WorkingHoursMinLength)]
        public string WorkingHours { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
