namespace Booking_Airline.Application.Services.Interfaces;

public interface IPasswordHasherService
{
    public string HashPassword(string password);
    public bool VerifyPassword(string password, string hashedPassword);
}
