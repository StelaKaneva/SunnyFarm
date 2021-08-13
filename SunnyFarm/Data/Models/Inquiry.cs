namespace SunnyFarm.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.PersonalData;

    public class Inquiry
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(PhoneMaxLength)]
        [Phone]
        public string Phone { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
