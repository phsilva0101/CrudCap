namespace CrudCap.Domain.ViewModels.Location
{
    public class CityModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual StateModel State { get; set; }

    }
}
