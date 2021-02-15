using FoodPal.Providers.DomainModels;

namespace FoodPal.Providers.Dtos.Mappers
{
    internal class ProviderProfile : BaseProfile
    {
        public ProviderProfile()
        {
            CreateMap<Provider, ProviderDto>().ReverseMap();
            // CreateMap<ProviderDto, Provider>();

            CreateMap<Provider, NewProviderDto>().ReverseMap();
            CreateMap<ProviderCategory, ProviderCategoryDto>().ReverseMap();
        }
    }
}