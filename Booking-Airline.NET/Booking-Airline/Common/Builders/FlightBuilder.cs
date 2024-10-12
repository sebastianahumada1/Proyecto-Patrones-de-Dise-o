using Booking_Airline.Domain;

namespace Booking_Airline.Common.Builders;

public class FlightBuilder
{
    private readonly Flight _flight = new();

    public FlightBuilder WithId(long id)
    {
        _flight.Id = id;
        return this;
    }

    public FlightBuilder WithDepartureCity(City departureCity)
    {
        _flight.DepartureCity = departureCity;
        return this;
    }

    public FlightBuilder WithArrivalCity(City arrivalCity)
    {
        _flight.ArrivalCity = arrivalCity;
        return this;
    }

    public FlightBuilder WithDepartureTime(DateOnly departureDate)
    {
        _flight.DepartureDate = departureDate;
        return this;
    }

    public FlightBuilder WithArrivalTime(DateOnly arrivalDate)
    {
        _flight.ArrivalDate = arrivalDate;
        return this;
    }

    public FlightBuilder WithPrice(decimal price)
    {
        _flight.Price = price;
        return this;
    }

    public FlightBuilder WithAirplane(Airplane airplane)
    {
        _flight.Airplane = airplane;
        return this;
    }

    public Flight Build()
    {
        return _flight;
    }
}
