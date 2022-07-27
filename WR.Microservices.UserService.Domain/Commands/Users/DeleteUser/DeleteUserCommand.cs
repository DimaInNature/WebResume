namespace WR.Microservices.UserService.Domain.Commands.Users;

public sealed record class DeleteUserCommand : IRequest
{
    public Guid Id { get; }

	public DeleteUserCommand(Guid id) => Id = id;

	public DeleteUserCommand() { }
}