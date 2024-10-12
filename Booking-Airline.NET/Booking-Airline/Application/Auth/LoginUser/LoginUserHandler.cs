using Booking_Airline.Common;
using Booking_Airline.Common.Results;
using Booking_Airline.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Booking_Airline.Application.Auth.LoginUser;

public class LoginUserHandler(IUserRepository userRepository) 
    : IRequestHandler<LoginUserCommand, Result<LoginUserResponse>>
{
    public async Task<Result<LoginUserResponse>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.LoginAsync(request);

        if (user is null)
        {
            return Result<LoginUserResponse>.Failure(ResponseMessages.InvalidCredentials);
        }

        if (user.Equals(new Domain.User()))
        {
            return Result<LoginUserResponse>.Failure(ResponseMessages.UserNotExists);
        }


        return Result<LoginUserResponse>.Success(new LoginUserResponse
        {
            UserId      = user.Id,
            Email       = user.Email,
            FullName    = user.FullName
        });
    }
}
