using Booking_Airline.Application.Services.Interfaces;
using Booking_Airline.Common.Enums;

namespace Booking_Airline.Application.Services;

public class FlightClassCategoryService : IFlightClassCategoryService
{
    public decimal CalculatePrice(decimal basePrice, FlightClassCategory flightClassCategory)
    {
        var strategy = GetStrategy(flightClassCategory);
        return strategy.CalculatePrice(basePrice);
    }

    public IFlightClassCategoryStrategy GetStrategy(FlightClassCategory flightClassCategory)
    {
        return flightClassCategory switch
        {
            FlightClassCategory.Economy => new EconomyClassStrategy(),
            FlightClassCategory.Basic => new BasicClassStrategy(),
            FlightClassCategory.Business => new BusinessClassStrategy(),
            _ => throw new NotImplementedException()
        };
    }

}
