using Booking_Airline.Common.Results;
using MediatR;

namespace Booking_Airline.Application.Auth.LoginUser;

public class LoginUserCommand : IRequest<Result<LoginUserResponse>>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class LoginUserResponse
{
    public long UserId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
