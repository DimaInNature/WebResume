namespace WR.Consumers.Desktop.Domain.Core.Models.Configuration.Routes;

public class RoutesSettingsModel
{
    public string GatewayRoute { get; set; } = string.Empty;

    public string AuthenticationRoute { get; set; } = string.Empty;

    public ContactMessageRoutesSettingsModel ContactMessages { get; set; } = new();

    public PetProjectRoutesSettingsModel PetProjects { get; set; } = new();

    public UserRoutesSettingsModel Users { get; set; } = new();

    public UserRoleRoutesSettingsModel UserRoles { get; set; } = new();
}