namespace CrudCap.Domain.ViewModels.Location
{
    public class StateModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Initials { get; set; }
        public CountryModel Country { get; set; }

    }
}
