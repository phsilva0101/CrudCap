using CrudCap.Domain.Entities.Location;
using CrudCap.Domain.Enums;

namespace CrudCap.Domain.Entities.Propertie
{
    public class Properties : BaseEntity
    {
        public string Description { get; set; }
        public decimal Value { get; set; }
        public PropertyType PropertyType { get; set; }

        public string Number { get; set; }

        public int Rooms { get; set; }
        public int Suites { get; set; }
        public bool HasGarage { get; set; }
        public int? GarageSpaces { get; set; }
        public int AreaM2 { get; set; }
        public bool HasPool { get; set; }
        public bool IsParticular { get; set; }

        public Guid? RealEstateId { get; set; }
        public virtual RealEstate? RealEstate { get; set; }

        #region Address
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string Complement { get; set; }
        public string ZipCode { get; set; }

        public Guid CityId { get; set; }
        public virtual City City { get; set; }


        #endregion


    }
}
