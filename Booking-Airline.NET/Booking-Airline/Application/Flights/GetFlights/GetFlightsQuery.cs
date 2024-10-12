using Booking_Airline.Common.Results;
using MediatR;

namespace Booking_Airline.Application.Flights.GetFlights;

public class GetFlightsQuery : IRequest<Result<List<GetFlightsResponse>>>
{
    public string? DepartureCity { get; set; }
    public string? ArrivalCity { get; set; }
    public string? DepartureDate { get; set; }
    public string? ArrivalDate { get; set; }
}


public class GetFlightsResponse
{
    public long Id { get; set; }
    public string DepartureCity { get; set; } = string.Empty;
    public string ShortDepartureCity { get; set; } = string.Empty;
    public string ArrivalCity { get; set; } = string.Empty;
    public string ShortArrivalCity { get; set; } = string.Empty;
    public DateOnly DepartureDate { get; set; }
    public DateOnly ArrivalDate { get; set; }
    public string AirlineName { get; set; } = string.Empty;
    public string AirplaneModel { get; set; } = string.Empty;
    public int AirplaneCapacity { get; set; }
    public string RegistrationNumber { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
