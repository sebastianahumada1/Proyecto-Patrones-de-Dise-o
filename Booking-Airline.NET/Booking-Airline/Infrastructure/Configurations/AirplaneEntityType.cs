using Booking_Airline.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Booking_Airline.Infrastructure.Configurations;

public class AirplaneEntityType : IEntityTypeConfiguration<Airplane>
{
    public void Configure(EntityTypeBuilder<Airplane> builder)
    {
        builder.ToTable("Airplanes");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Model)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.Capacity)
            .IsRequired();

        builder.Property(a => a.RegistrationNumber)
            .IsRequired()
            .HasMaxLength(20);

        builder.HasOne(a => a.Airline)
            .WithMany(a => a.Airplanes)
            .HasForeignKey(a => a.AirlineId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
