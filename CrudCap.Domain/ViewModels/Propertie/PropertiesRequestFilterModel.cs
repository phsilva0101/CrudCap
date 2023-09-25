using CrudCap.Domain.Enums;
using CrudCap.Domain.ViewModels.Base;

namespace CrudCap.Domain.ViewModels.Propertie
{
    public class PropertiesRequestFilterModel : BaseViewModel
    {
        public Guid? RealEstateId { get; set; }
        public PropertyType? PropertyType { get; set; }
        public Guid? CityId { get; set; }
        public Guid? StateId { get; set; }
        public Guid? CountryId { get; set; }
        public bool? IsParticular { get; set; }
        public bool? HasPool { get; set; }
        public bool? HasGarage { get; set; }
        public int? GarageSpaces { get; set; }
        public int? Rooms { get; set; }
        public int? Suites { get; set; }
        public decimal? ValueStart { get; set; }
        public decimal? ValueEnd { get; set; }

    }
}
