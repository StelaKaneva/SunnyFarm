namespace SunnyFarm.Services.Partners
{
    using System.Linq;
    using SunnyFarm.Data;
    
    public class PartnerService : IPartnerService
    {
        private readonly SunnyFarmDbContext data;

        public PartnerService(SunnyFarmDbContext data)
        {
            this.data = data;
        }

        public bool IsPartner(string userId)
            => this.data
            .Partners
            .Any(d => d.UserId == userId);
    }
}
