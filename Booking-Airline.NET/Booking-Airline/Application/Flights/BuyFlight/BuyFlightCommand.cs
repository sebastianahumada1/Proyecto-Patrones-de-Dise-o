using Booking_Airline.Common.Enums;
using Booking_Airline.Common.Results;
using MediatR;

namespace Booking_Airline.Application.Flights.BuyFlight;

public class BuyFlightCommand : IRequest<Result<CreatedId>>
{
    public long FlightId { get; set; }
    public long UserId { get; set; }
    public string SeatNumber { get; set; } = string.Empty;
    public FlightClassCategory FlightClassCategory { get; set; }
}
