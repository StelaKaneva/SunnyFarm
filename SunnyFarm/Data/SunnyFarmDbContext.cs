namespace SunnyFarm.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using SunnyFarm.Data.Models;

    public class SunnyFarmDbContext : IdentityDbContext
    {
        public SunnyFarmDbContext(DbContextOptions<SunnyFarmDbContext> options)
            : base(options)
        {
        }

        DbSet<Inquiry> Inquiries { get; init; }
    }
}
