using Booking_Airline.Common;
using Booking_Airline.Common.Builders;
using Booking_Airline.Common.Results;
using Booking_Airline.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Booking_Airline.Application.Flights.BuyFlight;

public class BuyFlightHandler(IPassengerRepository passengerRepository)
    : IRequestHandler<BuyFlightCommand, Result<CreatedId>>
{
    public async Task<Result<CreatedId>> Handle(BuyFlightCommand request, CancellationToken cancellationToken)
    {
        var exists = await passengerRepository.ExistsByUserIdAndFlightIdAsync(request.UserId, request.FlightId); // Repository pattern

        switch(exists) // returns a Result object (Result pattern)
        {
            case -1:
                return Result<CreatedId>.Failure(ResponseMessages.FlightNotExists); 
            case 0:
                return Result<CreatedId>.Failure(ResponseMessages.UserNotExists);
            case 1:
                return Result<CreatedId>.Failure(ResponseMessages.PassengerExists);
        }

        var passenger = new PassengerBuilder()
            .WithUserId(request.UserId)
            .WithFlightId(request.FlightId)
            .WithSeatNumber(request.SeatNumber)
            .WithFlightClassCategory(request.FlightClassCategory)
            .Build(); // Builder pattern

        await passengerRepository.AddAsync(passenger);
        await passengerRepository.SaveAsync();

        return Result<CreatedId>.Success(new CreatedId(passenger.Id));  // returns a Result object (Result pattern)
    }
}
