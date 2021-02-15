using AutoMapper;
using FoodPal.Providers.Dtos;
using FoodPal.Providers.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FoodPal.Providers.API.Controllers
{
    [Route("api/providers/{providerId}/menu")]
    [ApiController]
    public class CatalogueItemsController : ControllerBase
    {
        private readonly ICatalogueItemService _catalogueItemService;
        private readonly IProviderService _providerService;
        private readonly IMapper _mapper;

        public CatalogueItemsController(ICatalogueItemService catalogueItemService, IProviderService providerService, IMapper mapper)
        {
            _catalogueItemService = catalogueItemService ?? throw new ArgumentNullException(nameof(catalogueItemService));
            _providerService = providerService ?? throw new ArgumentNullException(nameof(providerService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }

        [HttpGet]
        public async Task<IActionResult> GetCatalogueItems(int providerId)
        {
            return NoContent();
        }

        [HttpGet("{itemId}")]
        public async Task<IActionResult> GetCatalogueItem(int providerId, int itemId)
        {
            return NoContent();
        }


    }
}