using CrediAuto.API.Profiles.Domain.Model.Commands;
using CrediAuto.API.Profiles.Domain.Model.ValueObjects;

namespace CrediAuto.API.Profiles.Domain.Model.Aggregates;

public partial class Profile
{
    public int Id { get; }
    public PersonName Name { get; private set; }
    public EmailAddress Email { get; private set; }
    public StreetAddress Address { get; private set; }
    public int UserId { get; private set; }

    public string FullName => Name.FullName;
    public string EmailAddress => Email.Address;
    public string StreetAddress => Address.FullAddress;

    public Profile()
    {
        Name = new PersonName();
        Email = new EmailAddress();
        Address = new StreetAddress();
    }

    public Profile(string firstName, string lastName, string email, string street, string city, string state,
        string postalCode, string country, int userId = 0)
    {
        Name = new PersonName(firstName, lastName);
        Email = new EmailAddress(email);
        Address = new StreetAddress(street, city, state, postalCode, country);
        UserId = userId;
    }

    public Profile(CreateProfileCommand command)
    {
        Name = new PersonName(command.FirstName, command.LastName);
        Email = new EmailAddress(command.Email);
        Address = new StreetAddress(command.Street, command.Number, command.City, command.PostalCode, command.Country);
        UserId = command.UserId;
    }
}
