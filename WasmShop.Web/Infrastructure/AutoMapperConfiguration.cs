using AutoMapper;
using WasmShop.Model.Models;
using WasmShop.Web.Models;

namespace WasmShop.Web.Infrastructure
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper.Configuration.AssertConfigurationIsValid();
        }
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductCategory, ProductCategoryViewModel>();
            CreateMap<ProductTag, ProductTagViewModel>();
            CreateMap<Tag, TagViewModel>();
            CreateMap<Size, SizeViewModel>();
        }
    }
}