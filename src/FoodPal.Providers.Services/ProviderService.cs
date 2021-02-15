using AutoMapper;
using FoodPal.Providers.DataAccess.UnitOfWork;
using FoodPal.Providers.DomainModels;
using FoodPal.Providers.Dtos;
using FoodPal.Providers.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodPal.Providers.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IUnitOfWork _uow;

        public IMapper _mapper { get; }

        public ProviderService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ProviderDto> CreateAsync(NewProviderDto provider)
        {
            var model = _mapper.Map<NewProviderDto, Provider>(provider);
            await _uow.ProviderRepository.AddAsync(model);

            await _uow.CommitAsync();

            return _mapper.Map<Provider, ProviderDto>(model);
        }

        public async Task DeleteAsync(int providerId)
        {
            var modelToBeDeleted = await _uow.ProviderRepository.GetWithCatalogueItemsByIdAsync(providerId);

            modelToBeDeleted.Catalogue.Items.ForEach(item =>
            {
                _uow.CatalogueItemsRepository.Remove(item);
            });

            _uow.CatalogueRepository.Remove(modelToBeDeleted.Catalogue);
            _uow.ProviderRepository.Remove(modelToBeDeleted);

            await _uow.CommitAsync();

        }

        public async Task<IEnumerable<ProviderDto>> GetAllAsync(bool includeCatalogueItems)
        {
            IEnumerable<Provider> models;

            if (includeCatalogueItems)
                models = await _uow.ProviderRepository.GetAllWithCatalogueItemsAsync();
            else
                models = await _uow.ProviderRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<Provider>, IEnumerable<ProviderDto>>(models);
        }

        public async Task<ProviderDto> GetByIdAsync(int providerId, bool includeCatalogueItems = false)
        {
            Provider model;

            if (includeCatalogueItems)
                model = await _uow.ProviderRepository.GetWithCatalogueItemsByIdAsync(providerId);
            else
                model = await _uow.ProviderRepository.SingleOrDefaultAsync(x => x.Id == providerId);

            return _mapper.Map<Provider, ProviderDto>(model);
        }

        public async Task<bool> ProvidersExistsAsync(string providerName)
        {
            var providerFound = await _uow.ProviderRepository.SingleOrDefaultAsync(x => x.Name.ToLower() == providerName.ToLower());

            return providerFound != null;
        }

        public async Task UpdateAsync(ProviderDto provider)
        {
            var entity = await _uow.ProviderRepository.SingleOrDefaultAsync(x => x.Id == provider.Id);

            var catalogue = await _uow.CatalogueRepository.SingleOrDefaultAsync(x => x.Id == provider.Catalogue.Id);

            entity.Name = provider.Name;
            catalogue.Description = provider.Catalogue.Description;

            await _uow.CommitAsync();

        }
    }
}