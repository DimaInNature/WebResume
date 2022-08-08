namespace WR.Consumers.Desktop.Domain.Core.Models;

public class User
{
    public Guid Id { get; } = Guid.NewGuid();

    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public UserRole? UserRole { get; set; }

    public Guid? UserRoleId { get; set; }

    public User(string username, string password) =>
        (Username, Password) = (username, password);

    public User(string username, string password, Guid userRoleId)
        : this(username, password) =>
        UserRoleId = userRoleId;

    public User() { }
}