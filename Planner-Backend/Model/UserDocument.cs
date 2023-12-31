using Planner_Backend.Mongo;

namespace Planner_Backend.Model;

[BsonCollection("users")]
public class UserDocument : Document
{
    public UserDocument(string? password, string? email, string? firstName, string? lastName, string? phoneNumber,
        DateTime birthDate)
    {
        Password = password;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        BirthDate = birthDate;
    }

    public string? Password { get; private set; }
    public string? Email { get; private set; }
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    public string? PhoneNumber { get; private set; }
    public DateTime BirthDate { get; private set; }
}