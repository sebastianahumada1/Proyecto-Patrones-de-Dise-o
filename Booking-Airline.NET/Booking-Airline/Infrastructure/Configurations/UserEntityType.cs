using Booking_Airline.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking_Airline.Infrastructure.Configurations;

public class UserEntityType : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users")
            .HasKey(user => user.Id);

        builder.Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.LastName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(500);

        builder.HasIndex(u => u.Email)
            .IsUnique();
    }
}
