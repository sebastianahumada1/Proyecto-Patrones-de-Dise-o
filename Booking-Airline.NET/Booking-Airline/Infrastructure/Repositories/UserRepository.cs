using Booking_Airline.Application.Auth.LoginUser;
using Booking_Airline.Application.Services.Interfaces;
using Booking_Airline.Domain;
using Booking_Airline.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Booking_Airline.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext applicationDbContext, IPasswordHasherService passwordHasher)
    : Repository<User>(applicationDbContext), IUserRepository
{
    public async Task<bool> ExistsUserAsync(string email)
        => await _dbSet.AnyAsync(user => user.Email == email);

    public async Task<User?> LoginAsync(LoginUserCommand login)
    {
        var verifiedUser = await _dbSet.FirstOrDefaultAsync(user => user.Email == login.Email);
        if (verifiedUser is null) return new();

        return passwordHasher.VerifyPassword(login.Password, verifiedUser.Password) ? verifiedUser : null;
    }
}
