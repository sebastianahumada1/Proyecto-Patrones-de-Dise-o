using Booking_Airline.Common.Results;
using MediatR;

namespace Booking_Airline.Application.Auth.CreateUser;

public class CreateUserCommand : IRequest<Result<CreatedId>>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}