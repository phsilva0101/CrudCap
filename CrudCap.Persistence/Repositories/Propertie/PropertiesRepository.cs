using CrudCap.CrossCutting.Extensions;
using CrudCap.Domain.Entities.Propertie;
using CrudCap.Domain.Interfaces.Propertie;
using CrudCap.Domain.ViewModels.Location;
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

        public async Task<(IEnumerable<PropertiesResponseFullModel> models, long count)> GetAllPropertiesAsync(PropertiesRequestFilterModel request, CancellationToken cancellationToken)
        {
            var query = _context.Properties
                 .Include(x => x.RealEstate)
                 .Include(x => x.City).ThenInclude(x => x.State).ThenInclude(x => x.Country)
                 .Where(x => x.DeactivationAt == null)
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
                query = query.Where(x => x.City.State.CountryId == request.CountryId.Value);
            }

            if (request.IsParticular.HasValue && request.IsParticular.Value)
            {
                query = query.Where(x => x.IsParticular == request.IsParticular.Value);
            }

            if (request.HasGarage.HasValue && request.HasGarage.Value)
            {
                query = query.Where(x => x.HasGarage == request.HasGarage.Value);
            }

            if (request.HasPool.HasValue && request.HasPool.Value)
            {
                query = query.Where(x => x.HasPool == request.HasPool.Value);
            }

            if (request.ValueStart.HasValue)
                query = query.Where(x => x.Value >= request.ValueStart.Value);

            if (request.ValueEnd.HasValue)
                query = query.Where(x => x.Value <= request.ValueEnd.Value);

            if (request.PropertyType.HasValue)
                query = query.Where(x => x.PropertyType == request.PropertyType.Value);

            if (!string.IsNullOrWhiteSpace(request.OrderBy))
                query = query.OrderByDynamic(request.OrderBy, request.Asc);
            else
                query = query.OrderByDescending(x => x.CreatedAt);


            var count = await query.LongCountAsync(cancellationToken);

            var models = await query
                .Select(x => new PropertiesResponseFullModel
                {
                    Id = x.Id,
                    Rooms = x.Rooms,
                    Value = x.Value,
                    Suites = x.Suites,
                    AreaM2 = x.AreaM2,
                    Description = x.Description,
                    PropertyType = x.PropertyType,
                    HasGarage = x.HasGarage,
                    GarageSpaces = x.GarageSpaces,
                    HasPool = x.HasPool,
                    IsParticular = x.IsParticular,
                    Complement = x.Complement,
                    Number = x.Number,
                    Street = x.Street,
                    Neighborhood = x.Neighborhood,
                    ZipCode = x.ZipCode,
                    City = new CityModel
                    {
                        Id = x.City.Id,
                        Name = x.City.Name,
                        State = new StateModel
                        {
                            Id = x.City.State.Id,
                            Name = x.City.State.Name,
                            Initials = x.City.State.Initials,
                            Country = new CountryModel
                            {
                                Id = x.City.State.Country.Id,
                                Name = x.City.State.Country.Name
                            }
                        }
                    },
                })
                .Skip(request.Skip)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            return (models, count);
        }

        public async Task<Properties> GetByIdWithEntitiesRelatedAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Properties
                .Include(x => x.RealEstate)
                .Include(x => x.City).ThenInclude(x => x.State).ThenInclude(x => x.Country)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
