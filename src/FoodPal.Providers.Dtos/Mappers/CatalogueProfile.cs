using FoodPal.Providers.DomainModels;

namespace FoodPal.Providers.Dtos.Mappers
{
    internal class CatalogueProfile : BaseProfile
    {
        public CatalogueProfile()
        {
            CreateMap<Catalogue, CatalogueDto>().ReverseMap();
            CreateMap<Catalogue, NewCatalogueDto>().ReverseMap();
        }
    }
}