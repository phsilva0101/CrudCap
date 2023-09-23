using CrudCap.Domain.Interfaces;
using CrudCap.Domain.Interfaces.Base;
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

        public async Task
    }
}
