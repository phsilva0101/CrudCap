using CrudCap.CrossCutting.Extensions;
using CrudCap.Domain.Entities;
using CrudCap.Domain.Interfaces;
using CrudCap.Domain.ViewModels.RealEstate;
using CrudCap.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace CrudCap.Persistence.Repositories.Propertie
{
    public class RealEstateRepository : BaseRepository<RealEstate>, IRealStateRepository
    {
        public RealEstateRepository(CrudCapContext context) : base(context)
        {
        }

        public async Task<(IEnumerable<RealEstate> entities, long count)> GetAllAsync(RealEstateRequestFilterModel request, CancellationToken cancellationToken)
        {
            var query = _context.RealEstates
                .Include(x => x.City).ThenInclude(x => x.State).ThenInclude(x => x.Country)
                .Where(x => x.DeactivationAt == null)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Name))
                query = query.Where(x => x.Name.Contains(request.Name));

            if (!string.IsNullOrWhiteSpace(request.OrderBy))
                query = query.OrderByDynamic(request.OrderBy, request.Asc);
            else
                query = query.OrderBy(x => x.Name);

            var count = await query.LongCountAsync(cancellationToken);

            var entities = await query.Skip(request.Skip).Take(request.PageSize).ToListAsync(cancellationToken);

            return (entities, count);

        }
    }
}
