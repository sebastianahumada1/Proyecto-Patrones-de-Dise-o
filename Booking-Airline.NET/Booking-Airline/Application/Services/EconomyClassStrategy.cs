using Booking_Airline.Application.Services.Interfaces;

namespace Booking_Airline.Application.Services;

public class EconomyClassStrategy : IFlightClassCategoryStrategy
{
    public decimal CalculatePrice(decimal basePrice)
    {
        return basePrice;
    }
}

public class BasicClassStrategy : IFlightClassCategoryStrategy
{
    public decimal CalculatePrice(decimal basePrice)
    {
        return basePrice * 1.15m;
    }
}

public class BusinessClassStrategy : IFlightClassCategoryStrategy
{
    public decimal CalculatePrice(decimal basePrice)
    {
        return basePrice * 1.50m;
    }
}
