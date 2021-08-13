namespace SunnyFarm.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;
    
    using static DataConstants.PersonalData;

    public class Partner
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(PhoneMaxLength)]
        [Phone]
        public string Phone { get; set; }

        [Required]
        public string UserId { get; set; }

        public IdentityUser User { get; set; }
    }
}
