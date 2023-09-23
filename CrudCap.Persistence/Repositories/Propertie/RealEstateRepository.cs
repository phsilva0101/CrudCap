using CrudCap.Domain.Entities;
using CrudCap.Domain.Interfaces;
using CrudCap.Persistence.Repositories.Base;

namespace CrudCap.Persistence.Repositories.Propertie
{
    public class RealEstateRepository : BaseRepository<RealEstate>, IRealStateRepository
    {
        public RealEstateRepository(CrudCapContext context) : base(context)
        {
        }
    }
}
