namespace WR.Microservices.UserService.Domain.Commands.Users;

public sealed record class CreateUserCommand : IRequest
{
    public UserEntity? User { get;}

    public CreateUserCommand(UserEntity entity) => User = entity;

    public CreateUserCommand() { }
}