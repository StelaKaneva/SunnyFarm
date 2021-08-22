namespace SunnyFarm.Infrastructure
{
    using AutoMapper;
    using SunnyFarm.Data.Models;
    using SunnyFarm.Models.Products;
    using SunnyFarm.Services.Products.Models;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<ProductDetailsServiceModel, ProductFormModel>()
                .ReverseMap();
            this.CreateMap<Product, ProductDetailsServiceModel>()
                .ForMember(p => p.CategoryName, cfg => cfg.MapFrom(p => p.Category.Name))
                .ReverseMap();
        }
    }
}
