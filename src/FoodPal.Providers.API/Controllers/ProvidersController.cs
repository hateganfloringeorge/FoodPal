using FoodPal.Providers.Dtos;
using FoodPal.Providers.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FoodPal.Providers.API.Controllers
{
    [Route("api/providers")]
    [ApiController]
    public class ProvidersController : ControllerBase
    {
        private readonly IProviderService _providerService;

        public ProvidersController(IProviderService providerService)
        {
            _providerService = providerService ?? throw new ArgumentNullException(nameof(providerService));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProviders(bool includeCatalogueItems)
        {
            try
            {
                var providers = await _providerService.GetAllAsync(includeCatalogueItems);
                return Ok(providers);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to succeed the operation!");
            }
        }

        [HttpGet("{id}", Name = "GetProvider")]
        public async Task<IActionResult> GetProvider(int id, bool includeCatalogueItems)
        {
            try
            {
                var provider = await _providerService.GetByIdAsync(id, includeCatalogueItems);

                if (provider == null)
                    return NotFound();

                return Ok(provider);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to succeed the operation!");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProvider(NewProviderDto provider)
        {
            try
            {
                if (provider.Location == provider.Name)
                {
                    ModelState.AddModelError(
                        "Location",
                        "The provider description should be different from rhe name!");
                }

                if (await _providerService.ProvidersExistsAsync(provider.Name))
                {
                    ModelState.AddModelError(
                        "Name",
                        "A provider with the same name already exists into the database!");
                }

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var insertedProvider = await _providerService.CreateAsync(provider);

                if (insertedProvider == null)
                    return Problem();

                return CreatedAtRoute("GetProvider", new { id = insertedProvider.Id }, insertedProvider);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to succeed the operation!");
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProvider(int id, [FromBody] ProviderDto provider)
        {
            try
            {
                if (provider.Id != id)
                {
                    ModelState.AddModelError(
                        "Identifier",
                        "Request body not apropiate for ID");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (await _providerService.GetByIdAsync(id) == null)
                {
                    return NotFound();
                }

                await _providerService.UpdateAsync(provider);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to succeed the operation!");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProvider(int id)
        {
            try
            {
                if (await _providerService.GetByIdAsync(id) == null)
                {
                    return NotFound();
                }

                await _providerService.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to succeed the operation!");
            }
        }

    }
}