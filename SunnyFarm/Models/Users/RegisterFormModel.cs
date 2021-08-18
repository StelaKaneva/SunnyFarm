namespace SunnyFarm.Models.Users
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.User;
    using static Data.DataConstants.PersonalData;

    public class RegisterFormModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string UserName { get; set; }

        [Required]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = PasswordMinLength)]
        public string Password { get; set; }

        [StringLength(FullNameMaxLength, MinimumLength = FullNameMinLength)]
        public string FullName { get; set; }

        [StringLength(PhoneMaxLength, MinimumLength = PhoneMinLength)]
        public string Phone { get; set; }

        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
        public string Address { get; set; }
    }
}
