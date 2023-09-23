using CrudCap.Domain.ViewModels.Base;
using CrudCap.Domain.ViewModels.RealEstate;

namespace CrudCap.Services.Interfaces.Propertie
{
    public interface IRealEstateService
    {
        Task<PaginationItemsResponse<RealEstateResponseModel>> GetAllRealEstate(RealEstateRequestFilterModel request, CancellationToken cancellationToken);
        Task InsertRealEstateAsync(RealEstateInsertModel model, CancellationToken cancellationToken);
        Task SoftDelete(Guid id, CancellationToken cancellationToken);
    }
}
