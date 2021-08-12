namespace SunnyFarm.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Shop
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(ShopNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; }

        [Required]
        [MaxLength(PhoneMaxLength)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(WorkingHoursMaxLength)]
        public string WorkingHours { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
