namespace SunnyFarm.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using SunnyFarm.Data.Models;
    using SunnyFarm.Models.Users;
    
    public class UsersController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public UsersController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterFormModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var registeredUser = new User 
            {
                UserName = user.UserName,
                Email = user.Email,
                FullName = user.FullName,
                PhoneNumber = user.Phone,
                Address = user.Address
            };

            var result = await this.userManager.CreateAsync(registeredUser, user.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                foreach (var error in errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }

                return View(user);
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginFormModel user)
        {
            var loggedInUser = await this.userManager.FindByNameAsync(user.UserName);

            if (loggedInUser == null)
            {
                return InvalidCredentials(user);
            }

            var passwordIsValid = await this.userManager.CheckPasswordAsync(loggedInUser, user.Password);

            if (!passwordIsValid)
            {
                return InvalidCredentials(user);
            }

            await this.signInManager.SignInAsync(loggedInUser, true);

            return RedirectToAction("Index", "Home");
        }

        private IActionResult InvalidCredentials(LoginFormModel user)
        {
            const string invalidCredentialsMessage = "Не съществува потребител с посочените данни.";

            ModelState.AddModelError(string.Empty, invalidCredentialsMessage);

            return View(user);
        }
    }
}
