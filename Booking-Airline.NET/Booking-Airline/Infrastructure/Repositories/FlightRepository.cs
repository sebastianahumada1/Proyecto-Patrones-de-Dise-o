using Booking_Airline.Domain;
using Booking_Airline.Infrastructure.Repositories.Interfaces;

namespace Booking_Airline.Infrastructure.Repositories;

public class FlightRepository(ApplicationDbContext applicationDbContext) 
    : Repository<Flight>(applicationDbContext), IFlightRepository
{
}
