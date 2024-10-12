using Booking_Airline.Common.Enums;
using Booking_Airline.Domain;

namespace Booking_Airline.Common.Builders;

public class PassengerBuilder
{
    private readonly Passenger _passenger = new();

    public PassengerBuilder WithUserId(long userId)
    {
        _passenger.UserId = userId;
        return this;
    }

    public PassengerBuilder WithFlightId(long flightId)
    {
        _passenger.FlightId = flightId;
        return this;
    }

    public PassengerBuilder WithFlightClassCategory(FlightClassCategory flightClassCategory)
    {
        _passenger.FlightClassCategory = flightClassCategory;
        return this;
    }

    public PassengerBuilder WithSeatNumber(string seatNumber)
    {
        _passenger.SeatNumber = seatNumber;
        return this;
    }

    public Passenger Build()
    {
        return _passenger;
    }

}
