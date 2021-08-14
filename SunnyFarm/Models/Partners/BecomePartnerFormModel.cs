namespace SunnyFarm.Models.Partners
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.PersonalData;

    public class BecomePartnerFormModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(PhoneMaxLength, MinimumLength = PhoneMinLength)]
        [Phone]
        public string Phone { get; set; }
    }
}
