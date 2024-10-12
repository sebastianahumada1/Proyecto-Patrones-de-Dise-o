using Booking_Airline.Common.Extensions;
using Booking_Airline.Common.Results;
using Booking_Airline.Domain;
using Booking_Airline.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Booking_Airline.Application.Flights.GetFlights;

public class GetFlightsHandler(ApplicationDbContext context) 
    : IRequestHandler<GetFlightsQuery, Result<List<GetFlightsResponse>>>
{
    public async Task<Result<List<GetFlightsResponse>>> Handle(GetFlightsQuery request, CancellationToken cancellationToken)
    {
        DateOnly? departureDate = request.DepartureDate is not null ? DateOnly.Parse(request.DepartureDate) : new();
        DateOnly? arrivalDate = request.ArrivalDate is not null ? DateOnly.Parse(request.ArrivalDate) : new();

        var flights = await context.Set<Flight>()
            .Include(flight => flight.ArrivalCity)
            .Include(flight => flight.DepartureCity)
            .OptionalWhere(request.ArrivalCity, flight => flight.DepartureCity.Name == request.DepartureCity || flight.DepartureCity.ShortName == request.DepartureCity)
            .OptionalWhere(request.ArrivalCity, flight => flight.ArrivalCity.Name == request.ArrivalCity || flight.ArrivalCity.ShortName == request.ArrivalCity)
            .OptionalWhere(request.DepartureDate, flight => flight.DepartureDate >= departureDate)
            .OptionalWhere(request.ArrivalDate, flight => flight.ArrivalDate <= arrivalDate)
            .Select(flight => new GetFlightsResponse
            {
                Id                  = flight.Id,
                DepartureCity       = flight.DepartureCity.Name,
                ShortDepartureCity  = flight.DepartureCity.ShortName,
                ArrivalCity         = flight.ArrivalCity.Name,
                ShortArrivalCity    = flight.ArrivalCity.ShortName,
                DepartureDate       = flight.DepartureDate,
                ArrivalDate         = flight.ArrivalDate,
                AirlineName         = flight.Airplane.Airline.Name,
                AirplaneModel       = flight.Airplane.Model,
                AirplaneCapacity    = flight.Airplane.Capacity,
                RegistrationNumber  = flight.Airplane.RegistrationNumber,
                Price               = flight.Price
            })
            .ToListAsync(cancellationToken);

        return Result<List<GetFlightsResponse>>.Success(flights);
    }
}
