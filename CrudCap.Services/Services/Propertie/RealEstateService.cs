using CrudCap.Domain.Entities;
using CrudCap.Domain.Interfaces;
using CrudCap.Domain.Interfaces.Base;
using CrudCap.Domain.ViewModels.Base;
using CrudCap.Domain.ViewModels.RealEstate;
using CrudCap.Services.Interfaces;
using CrudCap.Services.Interfaces.Propertie;

namespace CrudCap.Services.Services.Propertie
{
    public class RealEstateService : IRealEstateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRealStateRepository _realEstateRepository;
        private readonly IDomainValidationService _domainValidationService;

        public RealEstateService(IUnitOfWork unitOfWork, IRealStateRepository realEstateRepository, IDomainValidationService domainValidationService)
        {
            _unitOfWork = unitOfWork;
            _realEstateRepository = realEstateRepository;
            _domainValidationService = domainValidationService;
        }

        public async Task<PaginationItemsResponse<RealEstateResponseModel>> GetAllRealEstate(RealEstateRequestFilterModel request, CancellationToken cancellationToken)
        {

            (var entities, long count) = await _realEstateRepository.GetAllAsync(request, cancellationToken);

            var realEstate = entities.MapToModelList();

            return new PaginationItemsResponse<RealEstateResponseModel>(request.PageSize, request.PageNumber, count, realEstate);
        }

        public async Task InsertRealEstateAsync(RealEstateInsertModel model, CancellationToken cancellationToken)
        {

            if (ReferenceEquals(model, null))
                throw new ArgumentNullException(nameof(model));

            if (string.IsNullOrEmpty(model.Name))
            {
                _domainValidationService.AddMessage("Name is required");
                return;
            }

            if (string.IsNullOrEmpty(model.Cnpj))
            {
                _domainValidationService.AddMessage("Cnpj is required");
                return;
            }

            var realEstate = new RealEstate
            {
                Name = model.Name,
                ZipCode = model.ZipCode,
                CityId = model.CityId,
                Email = model.Email,
                Phone = model.Phone,
                Street = model.Street,
                Neighborhood = model.Neighborhood,
                Complement = model.Complement,
                Cnpj = model.Cnpj,
                Site = model.Site,
                Logo = model.Logo,

            };

            await _realEstateRepository.AddAsync(realEstate, cancellationToken);
            await _unitOfWork.CommitarTransacaoAsync(cancellationToken);
        }

        public async Task SoftDelete(Guid id, CancellationToken cancellationToken)
        {
            var entitiy = await _realEstateRepository.GetByIdAsync(id, cancellationToken);

            if (entitiy == null)
            {
                _domainValidationService.AsNotFound();
                return;
            }

            entitiy.DeactivationAt = DateTime.Now;

            await _unitOfWork.CommitarTransacaoAsync(cancellationToken);
        }
    }
}
