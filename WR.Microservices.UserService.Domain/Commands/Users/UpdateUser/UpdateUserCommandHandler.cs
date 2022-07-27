namespace WR.Microservices.UserService.Domain.Commands.Users;

public sealed record class UpdateUserCommandHandler
    : IRequestHandler<UpdateUserCommand>
{
    private readonly IGenericRepository<UserEntity> _repository;

    public UpdateUserCommandHandler(IGenericRepository<UserEntity> repository) => _repository = repository;

    public async Task<Unit> Handle(
        UpdateUserCommand request,
        CancellationToken token)
    {
        if (request.User is null) return Unit.Value;

        await _repository.UpdateAsync(entity: request.User, token);

        return Unit.Value;
    }
}