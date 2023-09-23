using CrudCap.Domain.Entities.Propertie;
using CrudCap.Domain.Enums;
using CrudCap.Domain.ViewModels.Location;

namespace CrudCap.Domain.ViewModels.Propertie
{
    public class PropertiesResponseFullModel
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

        public RealEstateModel RealEstate { get; set; }

        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string Complement { get; set; }
        public string ZipCode { get; set; }

        public virtual CityModel City { get; set; }



    }

    public static class PropertiesByIdModelExtensions
    {
        public static PropertiesResponseFullModel MapToModel(this Properties properties)
        {
            return new PropertiesResponseFullModel
            {
                Description = properties.Description,
                Value = properties.Value,
                AreaM2 = properties.AreaM2,
                GarageSpaces = properties.GarageSpaces,
                HasGarage = properties.HasGarage,
                HasPool = properties.HasPool,
                IsParticular = properties.IsParticular,
                Number = properties.Number,
                PropertyType = properties.PropertyType,
                Rooms = properties.Rooms,
                Suites = properties.Suites,
                Street = properties.Street,
                Neighborhood = properties.Neighborhood,
                Complement = properties.Complement,
                ZipCode = properties.ZipCode,
                City = properties.City == null ? null : new CityModel
                {
                    Id = properties.City.Id,
                    Name = properties.City.Name,

                    State = properties.City.State == null ? null : new StateModel
                    {
                        Name = properties.City.State.Name,
                        Initials = properties.City.State.Initials,
                        Id = properties.City.State.Id,
                        Country = properties.City.State.Country == null ? null : new CountryModel
                        {
                            Name = properties.City.State.Country.Name,
                            Initials = properties.City.State.Country.Initials,
                            Id = properties.City.State.Country.Id,
                        },
                    },
                },

                RealEstate = properties.RealEstate == null ? null : new RealEstateModel
                {
                    Name = properties.RealEstate.Name,
                    Cnpj = properties.RealEstate.Cnpj,
                    Email = properties.RealEstate.Email,
                    Logo = properties.RealEstate.Logo,
                    Phone = properties.RealEstate.Phone,
                    Site = properties.RealEstate.Site
                }

            };
        }

        public static IEnumerable<PropertiesResponseFullModel> MapToModelList(this IEnumerable<Properties> properties)
        {
            return properties.Select(x => x.MapToModel());
        }
    }
}
