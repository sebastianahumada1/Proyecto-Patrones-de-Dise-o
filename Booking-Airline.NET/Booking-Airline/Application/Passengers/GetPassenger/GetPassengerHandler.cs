using Booking_Airline.Application.Services.Interfaces;
using Booking_Airline.Common;
using Booking_Airline.Common.Results;
using Booking_Airline.Domain;
using Booking_Airline.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Booking_Airline.Application.Passengers.GetPassenger;

public class GetPassengerHandler(ApplicationDbContext context, IFlightClassCategoryService flightClassCategoryService) 
    : IRequestHandler<GetPassengerQuery, Result<GetPassengerResponse>>
{
    public async Task<Result<GetPassengerResponse>> Handle(GetPassengerQuery request, CancellationToken cancellationToken)
    {
        var exists = await context.Set<Passenger>()
            .Include(p => p.Flight)
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.FlightId == request.FlightId && p.Id == request.PassengerId, cancellationToken);

        if (exists is null)
        {
            return Result<GetPassengerResponse>.Failure(ResponseMessages.PassengerNotExists);
        }
        var price = flightClassCategoryService.CalculatePrice(exists.Flight.Price, exists.FlightClassCategory);

        return Result<GetPassengerResponse>.Success(new GetPassengerResponse
        {
            PassengerId         = exists.Id,
            Email               = exists.User.Email,
            FullName            = exists.User.FullName,
            SeatNumber          = exists.SeatNumber,
            FlightClassCategory = exists.FlightClassCategory.ToString(),
            TicketPrice         = price
        });

    }
}
