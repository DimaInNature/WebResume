namespace WR.Microservices.AuthenticationServices.Domain.Core.Models.Configuration;

public class JwtSettingsModel
{
    public string Issuer { get; set; } = string.Empty;

    public string Audience { get; set; } = string.Empty;

    public string Key { get; set; } = string.Empty;
}