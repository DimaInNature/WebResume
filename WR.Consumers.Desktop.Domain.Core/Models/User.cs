namespace WR.Consumers.Desktop.Domain.Core.Models;

public class User
{
    public Guid Id { get; } = Guid.NewGuid();

    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public User(string username, string password) => (Username, Password) = (username, password);
}