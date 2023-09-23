using CrudCap.Domain.Entities.Propertie;

namespace CrudCap.Domain.Entities.Location
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public Guid StateId { get; set; }
        public virtual State State { get; set; }
        public Guid CountryId { get; set; }
        public virtual Country Country { get; set; }

        public virtual ICollection<Properties> Properties { get; set; }
        public virtual ICollection<RealEstate> RealEstate { get; set; }


        public City()
        {
            Properties = new HashSet<Properties>();
            RealEstate = new HashSet<RealEstate>();
        }
    }
}