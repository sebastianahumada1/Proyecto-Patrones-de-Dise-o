using Booking_Airline.Common.Enums;

namespace Booking_Airline.Domain;

public class Passenger
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public User User { get; set; } = default!;
    public long FlightId { get; set; }
    public Flight Flight { get; set; } = default!;
    public FlightClassCategory FlightClassCategory { get; set; }

    public string SeatNumber { get; set; } = string.Empty; 
    public bool IsCheckedIn { get; set; } = false;
    public decimal TicketPrice => 1;
}
