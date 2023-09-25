using CrudCap.Domain.Enums;

namespace CrudCap.Domain.ViewModels.Propertie
{
    public class PropertiesInsertModel
    {
        public string Description { get; set; }
        public decimal Value { get; set; }
        public PropertyType PropertyType { get; set; }
        public int Rooms { get; set; }
        public int Suites { get; set; }
        public bool HasGarage { get; set; }
        public int? GarageSpaces { get; set; }
        public int AreaM2 { get; set; }
        public bool HasPool { get; set; }
        public bool IsParticular { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string ZipCode { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public string Initials { get; set; }
        public Guid? RealEstateId { get; set; }
    }
}
