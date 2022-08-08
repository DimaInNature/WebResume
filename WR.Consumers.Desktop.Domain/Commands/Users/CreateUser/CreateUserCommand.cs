namespace WR.Consumers.Desktop.Domain.Commands.Users;

public sealed record class CreateUserCommand : IRequest
{
    public User? User { get; }

    public CreateUserCommand(User entity) =>
        User = entity;

    public CreateUserCommand() { }
}