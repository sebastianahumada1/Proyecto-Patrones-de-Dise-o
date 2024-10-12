using Booking_Airline.Application.Services.Interfaces;

namespace Booking_Airline.Application.Services;

public class BcryptHasherService : IPasswordHasherService
{
    public string HashPassword(string password)
        => BCrypt.Net.BCrypt.HashPassword(password);

    public bool VerifyPassword(string password, string hashedPassword)
        => BCrypt.Net.BCrypt.Verify(password, hashedPassword);
}
