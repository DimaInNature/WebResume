namespace WR.Consumers.Desktop.Domain.Commands.Users;

public sealed record class DeleteUserCommand : IRequest
{
    public Guid Id { get; }

    public DeleteUserCommand(Guid id) => Id = id;

    public DeleteUserCommand() { }
}