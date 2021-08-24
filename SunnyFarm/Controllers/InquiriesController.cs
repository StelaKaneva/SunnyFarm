namespace SunnyFarm.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SunnyFarm.Models.Inquiries;
    using SunnyFarm.Services.Inquiries;

    public class InquiriesController : Controller
    {
        private readonly IInquiryService inquiries;

        public InquiriesController(IInquiryService inquiries)
        {
            this.inquiries = inquiries;
        }

        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(InquiryFormModel inquiry)
        {
            if (!ModelState.IsValid)
            {
                return View(inquiry);
            }

            this.inquiries.Create(
                inquiry.FirstName,
                inquiry.LastName,
                inquiry.Email,
                inquiry.Phone,
                inquiry.Message);

            return RedirectToAction("Index", "Home");
        }

    }
}
