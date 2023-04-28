using Aquaculture.Domain.Models;
using Aquaculture.Domain.PersonalContext.UserAggregate.Enums;
using Aquaculture.Domain.PersonalContext.UserAggregate.ValueObjects;

namespace Aquaculture.Domain.PersonalContext.UserAggregate;

public sealed class User : AggregateRoot<UserId>
{
    public string FullName { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string Password { get; private set; } = null!;
    public string Role { get; set; } = null!;

    private User(
        UserId id,
        string fullName,
        string email,
        string role,
        string password)
        : base(id)
    {
        FullName = fullName;
        Email = email;
        Password = password;
        Role = role;
    }

    public static User CreateNew(
        string fullname,
        string email,
        string password)
    {
        return new(
            UserId.CreateUnique(),
            fullname,
            email,
            UserRole.None,
            password);
    }

    public static User Create(
        UserId userId,
        string fullname,
        string email,
        string role,
        string password)
    {
        return new(
            userId,
            fullname,
            email,
            role,
            password);
    }

    public void Update(
        string? fullName,
        string? email,
        string? role,
        string? password)
    {
        FullName = fullName ?? FullName;
        Email = email ?? Email;
        Password = password ?? Password;
        Role = role ?? Role;
    }
}
