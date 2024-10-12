using Booking_Airline.Application.Services.Interfaces;
using Booking_Airline.Common.Results;
using Booking_Airline.Domain;
using Booking_Airline.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Booking_Airline.Application.Flights.GetPassengerFlights;

public class GetPassengerFlightsHandler(ApplicationDbContext context, IFlightClassCategoryService flightClassCategoryService)
    : IRequestHandler<GetPassengerFlightsQuery, Result<List<GetPassengerFlightsResponse>>>
{
    public async Task<Result<List<GetPassengerFlightsResponse>>> Handle(GetPassengerFlightsQuery request, CancellationToken cancellationToken)
    {
        var passengers = await context.Set<Passenger>()
            .Include(p => p.User)
            .Where(p => p.FlightId == request.FlightId)
            .Select(p => new GetPassengerFlightsResponse
            {
                PassengerId             = p.Id,
                FullName                = p.User.FullName,
                Email                   = p.User.Email,
                SeatNumber              = p.SeatNumber,
                FlightClassCategory     = p.FlightClassCategory.ToString(),
                FlightClassCategoryEnum = p.FlightClassCategory,
                Price                   = p.Flight.Price
            })
            .ToListAsync(cancellationToken);

        passengers.ForEach(p => p.TicketPrice = flightClassCategoryService.CalculatePrice(p.Price, p.FlightClassCategoryEnum));
        return Result<List<GetPassengerFlightsResponse>>.Success(passengers);
    }
}
