namespace WR.Microservices.UserService.Domain.Commands.Users;

public sealed record class CreateUserCommandHandler
    : IRequestHandler<CreateUserCommand>
{
    private readonly IGenericRepository<UserEntity> _repository;

    public CreateUserCommandHandler(
        IGenericRepository<UserEntity> repository) => _repository = repository;

    public async Task<Unit> Handle(
        CreateUserCommand request,
        CancellationToken token)
    {
        if (request.User is null) return Unit.Value;

        await _repository.CreateAsync(entity: request.User, token);

        return Unit.Value;
    }
}