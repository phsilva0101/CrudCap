namespace CrudCap.Domain.ViewModels.Location
{
    public class AddressModel
    {
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string Complement { get; set; }
        public string ZipCode { get; set; }

        public Guid CityId { get; set; }
        public Guid StateId { get; set; }
        public Guid CountryId { get; set; }

    }
}
