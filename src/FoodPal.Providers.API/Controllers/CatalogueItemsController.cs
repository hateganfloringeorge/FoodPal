using AutoMapper;
using FoodPal.Providers.Dtos;
using FoodPal.Providers.Services.Contracts;
using Microsoft.AspNetCore.Http;
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
            try
            {
                if (await _providerService.GetByIdAsync(providerId, false) == null)
                    return NotFound();

                var catalogueItems = await _catalogueItemService.GetCatalogueItemsForProviderAsync(providerId);
                return Ok(catalogueItems);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to succeed the operation!");
            }
        }

        [HttpGet("{itemId}", Name = "GetCatalogueItem")]
        public async Task<IActionResult> GetCatalogueItem(int providerId, int itemId)
        {
            try
            {
                if (await _providerService.GetByIdAsync(providerId, false) == null)
                    return NotFound();

                var catalogueItem = await _catalogueItemService.GetCatalogueItemByIdAsync(itemId);
                if (catalogueItem == null)
                    return NotFound();

                return Ok(catalogueItem);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to succeed the operation!");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCatalogueItem(int providerId, NewCatalogueItemDto catalogueItem)
        {
            try
            {
                if (await _providerService.GetByIdAsync(providerId, false) == null)
                    return NotFound();

                if (await _catalogueItemService.CatalogueItemExistsAsync(catalogueItem.Name, providerId))
                {
                    ModelState.AddModelError(
                        "Name",
                        "A catalogue item with the same name already exists");
                }

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var itemId = await _catalogueItemService.CreateAsync(catalogueItem);
                var insertedCatalogueItem = await _catalogueItemService.GetCatalogueItemByIdAsync(itemId);

                if (insertedCatalogueItem == null)
                    return Problem();

                return CreatedAtRoute("GetCatalogueItem", new { providerId, itemId = insertedCatalogueItem.Id }, insertedCatalogueItem);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to succeed the operation!");
            }

        }

        [HttpPut("{itemId}")]
        public async Task<IActionResult> UpdateCatalogueItem(int providerId, int itemId, [FromBody] CatalogueItemDto catalogueItem)
        {
            try
            {
                if (await _providerService.GetByIdAsync(providerId, false) == null)
                    return NotFound();

                if (await _catalogueItemService.GetCatalogueItemByIdAsync(itemId) == null)
                    return NotFound();

                if (catalogueItem.Id != itemId)
                {
                    ModelState.AddModelError(
                        "Identifier",
                        "Request body not apropiate for ID");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _catalogueItemService.UpdateAsync(catalogueItem);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to succeed the operation!");
            }
        }

        [HttpDelete("{itemId}")]
        public async Task<IActionResult> DeleteCatalogueItem(int itemId)
        {
            try
            {
                if (await _catalogueItemService.GetCatalogueItemByIdAsync(itemId) == null)
                {
                    return NotFound();
                }

                await _catalogueItemService.DeleteAsync(itemId);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to succeed the operation!");
            }
        }
    }
}