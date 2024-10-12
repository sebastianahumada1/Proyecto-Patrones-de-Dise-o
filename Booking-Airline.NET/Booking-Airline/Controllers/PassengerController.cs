using Booking_Airline.Application.Passengers.GetPassenger;
using Booking_Airline.Common.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Airline.Controllers;

[ApiController]
[Route("api/passengers")]
public class PassengerController(IMediator Mediator) : ControllerBase
{
    [HttpGet("{passengerId}/flights/{flightId}")]
    public async Task<ActionResult<Result<GetPassengerResponse>>> GetPassengerFlight(
        int passengerId, int flightId)
    {
        var query = new GetPassengerQuery
        {
            PassengerId = passengerId,
            FlightId = flightId
        };
        var result = await Mediator.Send(query);
        return result.IsSuccess
            ? Ok(result)
            : BadRequest(result);
    }

}
