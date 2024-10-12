using Booking_Airline.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Booking_Airline.Infrastructure.Configurations;

public class AirlineEntityType : IEntityTypeConfiguration<Airline>
{
    public void Configure(EntityTypeBuilder<Airline> builder)
    {
        builder.ToTable("Airlines");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasOne(a => a.Country)
            .WithMany(c => c.Airlines)
            .HasForeignKey(a => a.CountryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
