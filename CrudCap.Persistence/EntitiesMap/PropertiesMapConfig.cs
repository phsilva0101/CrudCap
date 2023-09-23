using CrudCap.Domain.Entities.Propertie;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrudCap.Persistence.EntitiesMap
{
    public class PropertiesMapConfig : IEntityTypeConfiguration<Properties>
    {
        public void Configure(EntityTypeBuilder<Properties> builder)
        {
            builder.ToTable("Properties");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Description)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Value).IsRequired().HasPrecision(12, 2);
            builder.Property(p => p.Number).HasMaxLength(10).IsRequired();
            builder.Property(p => p.Number).HasMaxLength(10).IsRequired();


            builder.HasOne(p => p.RealEstate)
                .WithMany(p => p.Properties)
                .HasForeignKey(p => p.RealEstateId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.Street)
               .IsRequired()
               .HasMaxLength(255);

            builder.Property(p => p.Neighborhood).IsRequired().HasMaxLength(255);

            builder.Property(p => p.Complement).HasMaxLength(255);

            builder.Property(p => p.ZipCode).IsRequired().HasMaxLength(10);

            builder.HasOne(p => p.City)
                .WithMany(p => p.Properties)
                .HasForeignKey(p => p.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.State).WithMany(p => p.Properties).HasForeignKey(p => p.StateId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Country)
                .WithMany(p => p.Properties)
                .HasForeignKey(p => p.CountryId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
