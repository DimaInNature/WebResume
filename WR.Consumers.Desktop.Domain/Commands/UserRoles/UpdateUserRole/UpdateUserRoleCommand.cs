namespace WR.Consumers.Desktop.Domain.Commands.UserRoles;

public sealed record class UpdateUserRoleCommand : IRequest
{
    public UserRole? UserRole { get; }

    public UpdateUserRoleCommand(UserRole entity) =>
        UserRole = entity;

    public UpdateUserRoleCommand() { }
}