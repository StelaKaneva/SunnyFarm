namespace SunnyFarm.Services.Inquiries
{
    using SunnyFarm.Data;
    using SunnyFarm.Data.Models;

    public class InquiryService : IInquiryService
    {
        private readonly SunnyFarmDbContext data;

        public InquiryService(SunnyFarmDbContext data)
        {
            this.data = data;
        }

        public int Create(string firstName, string lastName, string email, string phone, string message)
        {
            var inquiryData = new Inquiry
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone,
                Message = message
            };

            this.data.Inquiries.Add(inquiryData);
            this.data.SaveChanges();

            return inquiryData.Id;
        }
    }
}
