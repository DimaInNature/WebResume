namespace WR.Microservices.UserService.Domain.Commands.Users;

public sealed record class UpdateUserCommand : IRequest
{
    public UserEntity? User { get; }

    public UpdateUserCommand(UserEntity entity) => User = entity;

    public UpdateUserCommand() { }
}