using CrudCap.Domain.Entities;
using CrudCap.Domain.Interfaces.Base;
using CrudCap.Domain.ViewModels.RealEstate;

namespace CrudCap.Domain.Interfaces
{
    public interface IRealStateRepository : IBaseRepository<RealEstate>
    {
        Task<(IEnumerable<RealEstate> entities, long count)> GetAllAsync(RealEstateRequestFilterModel request, CancellationToken cancellationToken);
    }
}
