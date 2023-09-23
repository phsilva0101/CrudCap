using CrudCap.Domain.Entities.Location;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrudCap.Persistence.EntitiesMap
{
    public class CityMapConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {

            builder.ToTable("City");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne(p => p.State)
                .WithMany(p => p.Cities)
                .HasForeignKey(p => p.StateId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
