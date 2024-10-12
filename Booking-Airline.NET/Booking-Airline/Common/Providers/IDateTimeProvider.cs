namespace Booking_Airline.Common.Providers;

public interface IDateTimeProvider
{
    public DateTime Now { get; }
    public DateTime UtcNow { get; }
}
