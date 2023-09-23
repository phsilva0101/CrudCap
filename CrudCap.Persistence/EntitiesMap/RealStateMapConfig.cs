using CrudCap.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrudCap.Persistence.EntitiesMap
{
    public class RealStateMapConfig : IEntityTypeConfiguration<RealEstate>
    {
        public void Configure(EntityTypeBuilder<RealEstate> builder)
        {
            builder.ToTable("RealEstate");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Cnpj).IsRequired().HasMaxLength(16);

            builder.Property(p => p.Site).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Phone).IsRequired().HasMaxLength(11);

            builder.Property(p => p.Logo).IsRequired().HasMaxLength(100);

            builder.Property(p => p.Neighborhood).IsRequired().HasMaxLength(255);

            builder.Property(p => p.Complement).HasMaxLength(255);

            builder.Property(p => p.ZipCode).IsRequired().HasMaxLength(10);

            builder.HasOne(p => p.City)
                .WithMany(p => p.RealEstate)
                .HasForeignKey(p => p.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.State)
                .WithMany(p => p.RealEstate)
                .HasForeignKey(p => p.StateId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Country)
                .WithMany(p => p.RealEstate)
                .HasForeignKey(p => p.CountryId)
                .OnDelete(DeleteBehavior.Restrict);




        }
    }
}
