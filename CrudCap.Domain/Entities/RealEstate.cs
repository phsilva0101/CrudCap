using CrudCap.Domain.Entities.Location;
using CrudCap.Domain.Entities.Propertie;

namespace CrudCap.Domain.Entities
{
    public class RealEstate : BaseEntity
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public string Site { get; set; }

        public string Logo { get; set; }

        #region Address
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string Complement { get; set; }
        public string ZipCode { get; set; }

        public Guid CityId { get; set; }
        public virtual City City { get; set; }

        public Guid StateId { get; set; }
        public virtual State State { get; set; }

        public Guid CountryId { get; set; }
        public virtual Country Country { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Properties> Properties { get; set; }

        public RealEstate()
        {
            Properties = new HashSet<Properties>();
        }
    }
}
