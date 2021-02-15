using FoodPal.Providers.DomainModels;

namespace FoodPal.Providers.Dtos.Mappers
{
    internal class CatalogueItemProfile : BaseProfile
    {
        public CatalogueItemProfile()
        {
            CreateMap<CatalogueItem, CatalogueItemDto>().ReverseMap();
            CreateMap<CatalogueItem, NewCatalogueItemDto>().ReverseMap();
            CreateMap<CatalogueItemCategory, CatalogueItemCategoryDto>().ReverseMap();

        }
    }
}