namespace SunnyFarm.Infrastructure
{
    using AutoMapper;
    using SunnyFarm.Models.Products;
    using SunnyFarm.Services.Products.Models;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<ProductDetailsServiceModel, ProductFormModel>();
        }
    }
}
