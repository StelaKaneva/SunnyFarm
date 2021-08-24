namespace SunnyFarm.Models.Inquiries
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.PersonalData;
    public class InquiryFormModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(PhoneMaxLength, MinimumLength = PhoneMinLength)]
        [Phone]
        public string Phone { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
