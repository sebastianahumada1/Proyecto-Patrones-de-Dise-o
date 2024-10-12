using Booking_Airline.Domain;
using Booking_Airline.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Booking_Airline.Infrastructure.Repositories;

public class PassengerRepository(ApplicationDbContext applicationDbContext)
    : Repository<Passenger>(applicationDbContext), IPassengerRepository
{
    /// <summary>
    /// Simple method to check if a passenger exists by userId and flightId
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="flightId"></param>
    /// <returns>-1: If flight doesn't exists.
    /// 0: If UserId doesn't exists.
    /// 1: If Passenger Exists</returns>
    public async Task<short> ExistsByUserIdAndFlightIdAsync(long userId, long flightId)
    {
        var existsFlight = await _applicationDbContext.Set<Flight>()
            .AnyAsync(p => p.Id == flightId);

        if(!existsFlight)
        {
            return -1;
        }

        var existsUser = await _applicationDbContext.Set<User>()
            .AnyAsync(u => u.Id == userId);

        if(!existsUser) 
        {
            return 0;
        }

        var existsPassenger = await _applicationDbContext.Set<Passenger>()
            .AnyAsync(p => p.UserId == userId && p.FlightId == flightId);

        return existsPassenger ? (short)1 : (short)2;
    }
}
