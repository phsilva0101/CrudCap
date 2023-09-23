using CrudCap.Domain.ViewModels.Location;

namespace CrudCap.Domain.ViewModels.RealEstate
{
    public class RealEstateResponseModel
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

        public CityModel City { get; set; }
    }

    public static class RealEstateResponseModelExtensions
    {
        public static RealEstateResponseModel MapToModel(this Domain.Entities.RealEstate realEstate)
        {
            return new RealEstateResponseModel
            {
                Name = realEstate.Name,
                Cnpj = realEstate.Cnpj,
                Site = realEstate.Site,
                Logo = realEstate.Logo,
                Street = realEstate.Street,
                Neighborhood = realEstate.Neighborhood,
                Complement = realEstate.Complement,
                ZipCode = realEstate.ZipCode,
                Phone = realEstate.Phone,
                Email = realEstate.Email,
                City = realEstate.City == null ? null : new CityModel
                {
                    Name = realEstate.City.Name,
                    State = realEstate.City.State == null ? null : new StateModel
                    {
                        Name = realEstate.City.State.Name,
                        Initials = realEstate.City.State.Initials,
                        Country = realEstate.City.State.Country == null ? null : new CountryModel
                        {
                            Name = realEstate.City.State.Country.Name,
                            Initials = realEstate.City.State.Country.Initials
                        }
                    }
                }
            };
        }

        public static IEnumerable<RealEstateResponseModel> MapToModelList(this IEnumerable<Domain.Entities.RealEstate> realEstates)
        {
            return realEstates.Select(realEstate => realEstate.MapToModel());
        }
    }
}
