namespace CrudCap.Domain.ViewModels.Propertie
{
    public class PropertiesUpdateModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public int? GarageSpaces { get; set; }
        public int Rooms { get; set; }
        public int Suites { get; set; }
    }
}
