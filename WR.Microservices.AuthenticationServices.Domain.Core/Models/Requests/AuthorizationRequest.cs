namespace WR.Microservices.AuthenticationServices.Domain.Core.Models.Requests;

public class AuthorizationRequest
{
    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public AuthorizationRequest(string username, string password) =>
        (Username, Password) = (username, password);

    public AuthorizationRequest() { }
}