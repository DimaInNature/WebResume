namespace WR.Microservices.AuthenticationServices.Domain.Core.Models.Configuration.Routes.Users;

public class GetUserByLoginAndPasswordRouteSettingsModel
{
    public string Host { get; set; } = string.Empty;

    public string Route { get; set; } = string.Empty;

    public string GetUserByLoginAndPassword(string username, string password) =>
        string.Format(format: Route, arg0: username, arg1: password);
}