namespace Booking_Airline.Infrastructure.Configurations;

using Booking_Airline.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class FlightEntityType : IEntityTypeConfiguration<Flight>
{
    public void Configure(EntityTypeBuilder<Flight> builder)
    {
        builder.ToTable("Flights");

        builder.HasKey(f => f.Id);

        builder.Property(f => f.DepartureDate)
            .IsRequired();

        builder.Property(f => f.ArrivalDate)
            .IsRequired();

        builder.Property(f => f.Price)
            .HasPrecision(10, 2)
            .IsRequired();

        builder.HasOne(f => f.Airplane)
            .WithMany(a => a.Flights)
            .HasForeignKey(f => f.AirplaneId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(f => f.DepartureCity)
            .WithMany(c => c.DepartureFlights)
            .HasForeignKey(f => f.DepartureCityId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(f => f.ArrivalCity)
            .WithMany(c => c.ArrivalFlights)
            .HasForeignKey(f => f.ArrivalCityId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

