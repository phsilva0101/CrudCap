using CrudCap.CrossCutting.Extensions;
using CrudCap.Domain.Entities.Propertie;
using CrudCap.Domain.Interfaces.Propertie;
using CrudCap.Domain.ViewModels.Propertie;
using CrudCap.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace CrudCap.Persistence.Repositories.Propertie
{
    public class PropertiesRepository : BaseRepository<Properties>, IPropertiesRepository
    {
        public PropertiesRepository(CrudCapContext context) : base(context)
        {
        }

        public Task<(IEnumerable<Properties> models, long count)> GetAllPropertiesAsync(PropertiesRequestFilterModel request, CancellationToken cancellationToken)
        {
            var query = _context.Properties
                 .Include(x => x.RealEstate)
                 .Include(x => x.City).ThenInclude(x => x.State)
                 .Include(x => x.City).ThenInclude(x => x.Country)
                 .AsQueryable();

            if (request.RealEstateId.HasValue)
            {
                query = query.Where(x => x.RealEstateId == request.RealEstateId.Value);
            }

            if (request.CityId.HasValue)
            {
                query = query.Where(x => x.CityId == request.CityId.Value);
            }

            if (request.StateId.HasValue)
            {
                query = query.Where(x => x.City.StateId == request.StateId.Value);
            }

            if (request.CountryId.HasValue)
            {
                query = query.Where(x => x.City.CountryId == request.CountryId.Value);
            }

            if (request.IsParticular.HasValue)
            {
                query = query.Where(x => x.IsParticular == request.IsParticular.Value);
            }

            if (request.HasGarage.HasValue)
            {
                query = query.Where(x => x.HasGarage == request.HasGarage.Value);
            }

            if (request.HasPool.HasValue)
            {
                query = query.Where(x => x.HasPool == request.HasPool.Value);
            }

            if (!string.IsNullOrWhiteSpace(request.OrderBy))
                query = query.OrderByDynamic(request.OrderBy, request.Asc);
            else
                query = query.OrderByDescending(x => x.CreatedAt);


            var count = query.LongCountAsync(cancellationToken);

            var models = query
                .Skip(request.Skip)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            return (models, count);
        }

        public async Task<Properties> GetByIdWithEntitiesRelatedAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Properties
                .Include(x => x.RealEstate)
                .Include(x => x.City).ThenInclude(x => x.State)
                .Include(x => x.City).ThenInclude(x => x.Country)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
