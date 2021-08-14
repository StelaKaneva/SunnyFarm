namespace SunnyFarm.Controllers
{
    using System.Linq;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SunnyFarm.Data;
    using SunnyFarm.Data.Models;
    using SunnyFarm.Infrastructure;
    using SunnyFarm.Models.Partners;
    

    public class PartnersController : Controller
    {
        private readonly SunnyFarmDbContext data;

        public PartnersController(SunnyFarmDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        public IActionResult Become() => View();
        

        [HttpPost]
        [Authorize]
        public IActionResult Become(BecomePartnerFormModel partner)
        {
            var userId = this.User.GetId();


            var userIsAlreadyPartner = this.data
                .Partners
                .Any(p => p.UserId == userId);

            if (userIsAlreadyPartner)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(partner);
            }

            var partnerData = new Partner
            {
                Name = partner.Name,
                Phone = partner.Phone,
                UserId = userId
            };

            this.data.Partners.Add(partnerData);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

    }
}
