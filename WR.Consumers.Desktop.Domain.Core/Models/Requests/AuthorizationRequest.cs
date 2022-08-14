namespace WR.Consumers.Desktop.Domain.Core.Models.Requests;

public class AuthorizationRequest
{
    public string Username { get; } = string.Empty;

    public string Password { get; } = string.Empty;

    public AuthorizationRequest(string username, string password) =>
        (Username, Password) = (username, password);

    public AuthorizationRequest() { }
}