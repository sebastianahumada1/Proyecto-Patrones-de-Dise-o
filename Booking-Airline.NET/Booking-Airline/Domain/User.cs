namespace Booking_Airline.Domain;

public class User : IEquatable<User>
{
    public long Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public ICollection<Passenger> Passengers { get; set; } = [];
    public string FullName
        => $"{FirstName} {LastName}";

    public bool Equals(User? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id && FirstName == other.FirstName && LastName == other.LastName && Email == other.Email && Password == other.Password;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as User);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, FirstName, LastName, Email, Password);
    }
}
