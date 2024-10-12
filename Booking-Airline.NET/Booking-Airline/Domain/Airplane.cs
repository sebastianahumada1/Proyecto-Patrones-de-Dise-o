namespace Booking_Airline.Domain;

public class Airplane
{
    public long Id { get; set; }
    public string Model { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public long AirlineId { get; set; }
    public Airline Airline { get; set; } = default!;
    public string RegistrationNumber { get; set; } = string.Empty; 

    public ICollection<Flight> Flights { get; set; } = [];
}
