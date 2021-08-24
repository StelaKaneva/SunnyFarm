namespace SunnyFarm
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using SunnyFarm.Data;
    using SunnyFarm.Data.Models;
    using SunnyFarm.Infrastructure;
    using SunnyFarm.Services.Inquiries;
    using SunnyFarm.Services.Partners;
    using SunnyFarm.Services.Products;
    using SunnyFarm.Services.Shops;

    public class Startup
    {
        public Startup(IConfiguration configuration)
            => Configuration = configuration;
        

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContext<SunnyFarmDbContext>(options => options
                    .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services
                .AddDefaultIdentity<User>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<SunnyFarmDbContext>();

            services.AddAutoMapper(typeof(Startup));// Търси mappings в същия проект, в който се намира StartUp

            services.AddControllersWithViews(options =>
            {
                options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
            });

            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IShopService, ShopService>();
            services.AddTransient<IPartnerService, PartnerService>();
            services.AddTransient<IInquiryService, InquiryService>();
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.PrepareDatabase();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                
                app.UseHsts();
            }
            app.UseHttpsRedirection()
                .UseStaticFiles()
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapDefaultAreaRoute();
                    endpoints.MapDefaultControllerRoute();
                    endpoints.MapRazorPages();
                });
        }
    }
}
