using CrudCap.Domain.Entities.Propertie;
using CrudCap.Domain.Interfaces.Base;
using CrudCap.Domain.ViewModels.Propertie;

namespace CrudCap.Domain.Interfaces.Propertie
{
    public interface IPropertiesRepository : IBaseRepository<Properties>
    {
        Task<(IEnumerable<Properties> models, long count)> GetAllPropertiesAsync(PropertiesRequestFilterModel request, CancellationToken cancellationToken);
        Task<Properties> GetByIdWithEntitiesRelatedAsync(Guid id, CancellationToken cancellationToken);
    }
}
