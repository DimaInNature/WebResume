namespace WR.Microservices.AuthenticationServices.Domain.Core.Models.Configuration;

public class ApplicationSettingsModel
{
    public JwtSettingsModel Jwt { get; set; } = new();

    public RoutesSettingsModel Routes { get; set; } = new();
}