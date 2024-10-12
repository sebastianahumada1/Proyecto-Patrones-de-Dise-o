using Booking_Airline.Application.Auth.LoginUser;
using Booking_Airline.Domain;

namespace Booking_Airline.Infrastructure.Repositories.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<bool> ExistsUserAsync(string email);
    Task<User?> LoginAsync(LoginUserCommand login);
}
