namespace CrudCap.Domain.ViewModels.RealEstate
{
    public class RealEstateInsertModel
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public string Site { get; set; }

        public string Logo { get; set; }

        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string Complement { get; set; }
        public string ZipCode { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }

        public Guid CityId { get; set; }
    }
}
