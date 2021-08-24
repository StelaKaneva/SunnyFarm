namespace SunnyFarm.Services.Inquiries
{
    public interface IInquiryService
    {
        int Create(
            string firstName,
            string lastName,
            string email,
            string phone,
            string message);
    }
}