namespace WR.Consumers.Desktop.Domain.Commands.UserRoles;

public sealed record class CreateUserRoleCommand : IRequest
{
    public UserRole? UserRole { get; }

    public CreateUserRoleCommand(UserRole entity) =>
        UserRole = entity;

    public CreateUserRoleCommand() { }
}