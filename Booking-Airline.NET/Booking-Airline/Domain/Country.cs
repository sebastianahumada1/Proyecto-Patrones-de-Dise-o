namespace Booking_Airline.Domain;

public class Country
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<City> Cities { get; set; } = [];
    public ICollection<Airline> Airlines { get; set; } = [];
}
