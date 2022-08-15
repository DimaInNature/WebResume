namespace WR.Microservices.AuthenticationServices.Domain.Core.Models.Configuration.Routes.Users;

public class UserRoutesSettingsModel
{
    public GetUserByLoginAndPasswordRouteSettingsModel GetUserByLoginAndPasswordRoute { get; set; } = new();
}