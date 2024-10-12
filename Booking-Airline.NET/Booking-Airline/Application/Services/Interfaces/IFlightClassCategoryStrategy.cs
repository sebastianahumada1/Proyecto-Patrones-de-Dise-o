namespace Booking_Airline.Application.Services.Interfaces;

public interface IFlightClassCategoryStrategy
{
    decimal CalculatePrice(decimal basePrice);
}
