namespace Booking_Airline.Domain;

public class City
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ShortName { get; set; } = string.Empty;
    public long CountryId { get; set; }
    public Country Country { get; set; } = default!;

    public ICollection<Flight> ArrivalFlights { get; set; } = [];
    public ICollection<Flight> DepartureFlights { get; set; } = [];
}
