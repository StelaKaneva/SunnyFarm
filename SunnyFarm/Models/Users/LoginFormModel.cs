namespace SunnyFarm.Models.Users
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.PersonalData;
    using static Data.DataConstants.User;
    public class LoginFormModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string UserName { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = PasswordMinLength)]
        public string Password { get; set; }



    }
}
