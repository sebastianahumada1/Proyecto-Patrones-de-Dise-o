using Booking_Airline.Common.Results;
using MediatR;

namespace Booking_Airline.Application.Passengers.GetPassenger;

public class GetPassengerQuery : IRequest<Result<GetPassengerResponse>>
{
    public long FlightId { get; set; }
    public long PassengerId { get; set; }
}

public class GetPassengerResponse
{
    public long PassengerId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string SeatNumber { get; set; } = string.Empty;
    public string FlightClassCategory { get; set; } = string.Empty;
    public decimal TicketPrice { get; set; }
}
