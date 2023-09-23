using CrudCap.Domain.ViewModels.Base;
using CrudCap.Domain.ViewModels.Propertie;

namespace CrudCap.Services.Interfaces.Propertie
{
    public interface IPropertiesService
    {
        Task<PaginationItemsResponse<PropertiesResponseFullModel>> GetAllProperties(PropertiesRequestFilterModel request, CancellationToken cancellationToken);
        Task<PropertiesResponseFullModel> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Guid> InsertProperty(PropertiesInsertModel model, CancellationToken cancellationToken);
        Task SoftDelete(Guid id, CancellationToken cancellationToken);
        Task UpdateProperties(PropertiesUpdateModel model, CancellationToken cancellationToken);
    }
}
