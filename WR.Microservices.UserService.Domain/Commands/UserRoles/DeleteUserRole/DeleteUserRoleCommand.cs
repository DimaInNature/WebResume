namespace WR.Microservices.UserService.Domain.Commands.UserRoles;

public sealed record class DeleteUserRoleCommand : IRequest
{
    public Guid Id { get; }

	public DeleteUserRoleCommand(Guid id) => Id = id;

	public DeleteUserRoleCommand() { }
}