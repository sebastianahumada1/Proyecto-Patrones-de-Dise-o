using Booking_Airline.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking_Airline.Infrastructure.Configurations;

public class PassengerEntityType : IEntityTypeConfiguration<Passenger>
{
    public void Configure(EntityTypeBuilder<Passenger> builder)
    {
        builder.ToTable("Passengers");

        builder.HasKey(p => p.Id);

        builder.HasOne(p => p.User)
            .WithMany(u => u.Passengers)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relación con Flight
        builder.HasOne(p => p.Flight)
            .WithMany(f => f.Passengers)
            .HasForeignKey(p => p.FlightId)
            .OnDelete(DeleteBehavior.Cascade);


        builder.Property(p => p.FlightClassCategory)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(p => p.SeatNumber)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(p => p.IsCheckedIn)
            .IsRequired()
            .HasDefaultValue(false);
    }
}