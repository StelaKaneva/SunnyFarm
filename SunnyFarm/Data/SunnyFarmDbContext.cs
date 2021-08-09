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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(5,2)");
        }
    }
}
