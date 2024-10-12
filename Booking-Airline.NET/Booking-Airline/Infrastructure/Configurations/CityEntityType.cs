using Booking_Airline.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Booking_Airline.Infrastructure.Configurations;

public class CityEntityType : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("Cities");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.ShortName)
            .IsRequired()
            .HasMaxLength(5);

        builder.HasOne(c => c.Country)
            .WithMany(c => c.Cities)
            .HasForeignKey(c => c.CountryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
