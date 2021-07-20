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

        public DbSet<Inquiry> Inquiries { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Shop> Shops { get; set; }

        public DbSet<PriceSizeCombination> PriceSizeCombinations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PriceSizeCombination>().Property(p => p.Price).HasColumnType("decimal(4,2)");
        }
    }
}
