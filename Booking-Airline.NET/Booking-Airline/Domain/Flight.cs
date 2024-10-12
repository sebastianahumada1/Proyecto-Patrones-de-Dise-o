namespace Booking_Airline.Domain;

public class Flight
{
    public long Id { get; set; }
    public long AirplaneId { get; set; }
    public Airplane Airplane { get; set; } = default!;
    public long DepartureCityId { get; set; }
    public City DepartureCity { get; set; } = default!;
    public long ArrivalCityId { get; set; }
    public City ArrivalCity { get; set; } = default!;
    public DateOnly DepartureDate { get; set; }
    public DateOnly ArrivalDate { get; set; }
    public decimal Price { get; set; }
    public ICollection<Passenger> Passengers { get; set; } = []; 
}