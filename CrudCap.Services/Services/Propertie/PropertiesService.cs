using CrudCap.Domain.Entities.Propertie;
using CrudCap.Domain.Interfaces.Base;
using CrudCap.Domain.Interfaces.Propertie;
using CrudCap.Domain.ViewModels.Base;
using CrudCap.Domain.ViewModels.Propertie;
using CrudCap.Services.Interfaces;
using CrudCap.Services.Interfaces.Propertie;

namespace CrudCap.Services.Services.Propertie
{
    public class PropertiesService : IPropertiesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDomainValidationService _domainValidationService;
        private readonly IPropertiesRepository _propertiesRepository;
        public PropertiesService(IUnitOfWork unitOfWork, IDomainValidationService domainValidationService, IPropertiesRepository propertiesRepository)
        {
            _unitOfWork = unitOfWork;
            _domainValidationService = domainValidationService;
            _propertiesRepository = propertiesRepository;
        }

        public async Task<PaginationItemsResponse<PropertiesResponseFullModel>> GetAllProperties(PropertiesRequestFilterModel request, CancellationToken cancellationToken)
        {

            (var entities, long count) = await _propertiesRepository.GetAllPropertiesAsync(request, cancellationToken);

            var properties = entities.MapToModelList();

            return new PaginationItemsResponse<PropertiesResponseFullModel>(request.PageSize, request.PageNumber, count, properties);
        }

        public async Task<PropertiesResponseFullModel> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var property = await _propertiesRepository.GetByIdWithEntitiesRelatedAsync(id, cancellationToken);

            if (property == null)
            {
                _domainValidationService.AsNotFound();
                return null;
            }

            return property.MapToModel();
        }

        public async Task<Guid> InsertProperty(PropertiesInsertModel model, CancellationToken cancellationToken)
        {
            if (!model.IsParticular && !model.RealEstateId.HasValue)
            {
                _domainValidationService.AddMessage("Real Estate is required");
                return Guid.Empty;
            }

            if (model.HasGarage && (!model.GarageSpaces.HasValue || model.GarageSpaces.Value == 0))
            {
                _domainValidationService.AddMessage("Garage Spaces is required");
                return Guid.Empty;
            }

            var property = new Properties
            {
                Description = model.Description,
                Value = model.Value,
                RealEstateId = model.RealEstateId,
                AreaM2 = model.AreaM2,
                GarageSpaces = model.GarageSpaces,
                HasGarage = model.HasGarage,
                HasPool = model.HasPool,
                IsParticular = model.IsParticular,
                Number = model.Number,
                Rooms = model.Rooms,
                Suites = model.Suites,
                Complement = model.Complement,
                PropertyType = model.PropertyType,
                CityId = model.CityId,
                Neighborhood = model.Neighborhood,
                Street = model.Street,
                ZipCode = model.ZipCode,

            };

            await _propertiesRepository.AddAsync(property, cancellationToken);
            await _unitOfWork.CommitarTransacaoAsync(cancellationToken);

            return property.Id;
        }

        public async Task UpdateProperties(PropertiesUpdateModel model, CancellationToken cancellationToken)
        {
            var property = await _propertiesRepository.GetByIdAsync(model.Id, cancellationToken);

            if (property == null)
            {
                _domainValidationService.AsNotFound();
                return;
            }

            if (property.HasGarage && (!model.GarageSpaces.HasValue || model.GarageSpaces.Value == 0))
            {
                _domainValidationService.AddMessage("Garage Spaces is required");
                return;
            }

            property.Description = model.Description;
            property.Value = model.Value;
            property.GarageSpaces = model.GarageSpaces;
            property.Rooms = model.Rooms;
            property.Suites = model.Suites;

            await _unitOfWork.CommitarTransacaoAsync(cancellationToken);
        }

        public async Task SoftDelete(Guid id, CancellationToken cancellationToken)
        {
            var property = await _propertiesRepository.GetByIdAsync(id, cancellationToken);

            if (property == null)
            {
                _domainValidationService.AsNotFound();
                return;
            }

            property.DeactivationAt = DateTime.Now;

            await _unitOfWork.CommitarTransacaoAsync(cancellationToken);
        }


    }
}
