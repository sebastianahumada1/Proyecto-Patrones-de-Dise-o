using Booking_Airline.Domain;

namespace Booking_Airline.Infrastructure.Repositories.Interfaces;

public interface IPassengerRepository : IRepository<Passenger>
{
    public Task<short> ExistsByUserIdAndFlightIdAsync(long userId, long flightId);
}
