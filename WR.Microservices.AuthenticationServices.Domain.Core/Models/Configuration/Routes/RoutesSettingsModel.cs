namespace WR.Microservices.AuthenticationServices.Domain.Core.Models.Configuration.Routes;

public class RoutesSettingsModel
{
    public UserRoutesSettingsModel Users { get; set; } = new();
}