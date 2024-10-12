using Booking_Airline.Application.Flights.BuyFlight;
using Booking_Airline.Application.Flights.GetFlights;
using Booking_Airline.Application.Flights.GetPassengerFlights;
using Booking_Airline.Common.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Airline.Controllers;

[ApiController]
[Route("api/flights")]
public class FlightController(IMediator Mediator) 
    : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<Result<List<GetFlightsResponse>>>> GetFlightsAsync(
        [FromQuery] GetFlightsQuery query)
    {
        var flights = await Mediator.Send(query);
        return Ok(flights);
    }

    [HttpPost("buy")]
    public async Task<ActionResult<Result<CreatedId>>> BuyFlightAsync(
        [FromBody] BuyFlightCommand command)
    {
        var result = await Mediator.Send(command);
        return result.IsSuccess
            ? Ok(result)
            : BadRequest(result);
    }

    [HttpGet("{flightId}/passengers")]
    public async Task<ActionResult<Result<List<GetPassengerFlightsResponse>>>> GetPassengerFlightsAsync(int flightId)
    {
        var query = new GetPassengerFlightsQuery
        {
            FlightId = flightId
        };
        var result = await Mediator.Send(query);
        return result.IsSuccess
            ? Ok(result)
            : BadRequest(result);
    }
}
