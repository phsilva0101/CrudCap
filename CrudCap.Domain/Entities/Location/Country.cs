using CrudCap.Domain.Entities.Propertie;

namespace CrudCap.Domain.Entities.Location
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public string Initials { get; set; }

        public virtual ICollection<Properties> Properties { get; set; }
        public virtual ICollection<RealEstate> RealEstate { get; set; }
        public virtual ICollection<City> Cities { get; set; }


        public Country()
        {
            Properties = new HashSet<Properties>();
            RealEstate = new HashSet<RealEstate>();
            Cities = new HashSet<City>();
        }

    }
}