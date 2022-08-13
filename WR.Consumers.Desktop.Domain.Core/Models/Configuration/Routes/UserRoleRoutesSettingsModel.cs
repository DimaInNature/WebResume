namespace WR.Consumers.Desktop.Domain.Core.Models.Configuration.Routes;

public class UserRoleRoutesSettingsModel
{
    public string CreateUserRoleRoute { get; set; } = string.Empty;

    public string UpdateUserRoleRoute { get; set; } = string.Empty;

    public string DeleteUserRoleRoute { get; set; } = string.Empty;

    public string GetUserRolesListRoute { get; set; } = string.Empty;

    public string GetUserRoleByIdRoute { get; set; } = string.Empty;

    public string DeleteUserRole(Guid id) =>
        string.Format(format: DeleteUserRoleRoute, arg0: id);

    public string GetUserRoleById(Guid id) =>
        string.Format(format: GetUserRoleByIdRoute, arg0: id);
}