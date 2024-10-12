namespace Booking_Airline.Domain;

public class Airline
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public long CountryId { get; set; }
    public Country Country { get; set; } = default!;

    public ICollection<Airplane> Airplanes { get; set; } = [];
}
