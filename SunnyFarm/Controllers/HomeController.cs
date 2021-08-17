namespace SunnyFarm.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using SunnyFarm.Models;

    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Error() => View();
    }
}
