using Booking_Airline.Application.Auth.CreateUser;
using Booking_Airline.Application.Auth.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Airline.Controllers;

[ApiController]
[Route("api/users")]
public class UserController(IMediator Mediator) : ControllerBase
{
    [HttpPost("sign-up")]
    public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserCommand command)
    {
        var result = await Mediator.Send(command);
        return result.IsSuccess
            ? Ok(result)
            : BadRequest(result);
    }

    [HttpPost("sign-in")]
    public async Task<IActionResult> LoginUserAsync([FromBody] LoginUserCommand command)
    {
        var result = await Mediator.Send(command);
        return result.IsSuccess
            ? Ok(result)
            : BadRequest(result);
    }
}
