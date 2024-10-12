using Booking_Airline.Domain;

namespace Booking_Airline.Common.Builders;

public class UserBuilder
{
    private readonly User _user = new();

    public UserBuilder WithId(int id)
    {
        _user.Id = id;
        return this;
    }

    public UserBuilder WithEmail(string email)
    {
        _user.Email = email;
        return this;
    }

    public UserBuilder WithPassword(string password)
    {
        _user.Password = password;
        return this;
    }

    public UserBuilder WithFirstName(string firstName)
    {
        _user.FirstName = firstName;
        return this;
    }

    public UserBuilder WithLastName(string lastName)
    {
        _user.LastName = lastName;
        return this;
    }

    public User Build()
    {
        return _user;
    }
}
