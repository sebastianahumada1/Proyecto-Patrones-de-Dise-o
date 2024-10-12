using Booking_Airline.Common.Enums;

namespace Booking_Airline.Application.Services.Interfaces;

public interface IFlightClassCategoryService
{
    decimal CalculatePrice(decimal basePrice, FlightClassCategory flightClassCategory);
}
