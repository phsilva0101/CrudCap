using CrudCap.Domain.Entities.Propertie;

namespace CrudCap.Domain.Entities.Location
{
    public class State : BaseEntity
    {
        public string Name { get; set; }
        public string Initials { get; set; }
        public Guid CountryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Properties> Properties { get; set; }
        public virtual ICollection<RealEstate> RealEstate { get; set; }



        public State()
        {
            Cities = new HashSet<City>();
            Properties = new HashSet<Properties>();
            RealEstate = new HashSet<RealEstate>();
        }

    }
}