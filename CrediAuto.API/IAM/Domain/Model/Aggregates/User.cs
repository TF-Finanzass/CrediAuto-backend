using System.Text.Json.Serialization;
using CrediAuto.API.IAM.Domain.Model.Enums;

namespace CrediAuto.API.IAM.Domain.Model.Aggregates;

public class User(string username, string passwordHash, Roles role)
{
    public User() : this(string.Empty, string.Empty, Roles.Buyer)
    {
    }

    public int Id { get; }
    public string Username { get; private set; } = username;
    public Roles Role { get; private set; } = role;

    [JsonIgnore] public string PasswordHash { get; private set; } = passwordHash;

    public User UpdateUsername(string username)
    {
        Username = username;
        return this;
    }

    public User UpdatePasswordHash(string passwordHash)
    {
        PasswordHash = passwordHash;
        return this;
    }

    public User UpdateRole(Roles role)
    {
        Role = role;
        return this;
    }
}
