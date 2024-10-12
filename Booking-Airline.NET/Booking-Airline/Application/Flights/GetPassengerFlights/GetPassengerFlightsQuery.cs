using Booking_Airline.Common.Enums;
using Booking_Airline.Common.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace Booking_Airline.Application.Flights.GetPassengerFlights;

public class GetPassengerFlightsQuery : IRequest<Result<List<GetPassengerFlightsResponse>>>
{
    public long FlightId { get; set; }
}

public class GetPassengerFlightsResponse
{
    public long PassengerId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string SeatNumber { get; set; } = string.Empty;
    public string FlightClassCategory { get; set; } = string.Empty;
    public decimal TicketPrice { get; set; }

    [JsonIgnore]
    public FlightClassCategory FlightClassCategoryEnum { get; set; }

    [JsonIgnore]
    public decimal Price { get; set; }
}
