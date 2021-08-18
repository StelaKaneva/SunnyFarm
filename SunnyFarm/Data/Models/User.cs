namespace SunnyFarm.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.User;

    public class User : IdentityUser
    {
        [Required]
        [MaxLength(FullNameMaxLength)]
        public string FullName { get; set; }

        [MaxLength(AddressMaxLength)]
        public string Address { get; set; }
    }
}
