using Booking_Airline.Application.Services.Interfaces;
using Booking_Airline.Common;
using Booking_Airline.Common.Builders;
using Booking_Airline.Common.Results;
using Booking_Airline.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Booking_Airline.Application.Auth.CreateUser;

public class CreateUserHandler(IUserRepository userRepository, IPasswordHasherService passwordHasherService) 
    : IRequestHandler<CreateUserCommand, Result<CreatedId>>
{
    public async Task<Result<CreatedId>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var existsUser = await userRepository.ExistsUserAsync(request.Email);

        if (existsUser)
        {
            return Result<CreatedId>.Failure(ResponseMessages.UserExists);
        }

        var user = new UserBuilder()
            .WithEmail(request.Email)
            .WithPassword(passwordHasherService.HashPassword(request.Password))
            .WithFirstName(request.FirstName)
            .WithLastName(request.LastName)
            .Build();

        await userRepository.AddAsync(user);
        await userRepository.SaveAsync();

        return Result<CreatedId>.Success(new CreatedId(user.Id));
    }
}
