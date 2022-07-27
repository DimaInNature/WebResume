namespace WR.Microservices.UserService.Domain.Commands.Users;

public sealed record class DeleteUserCommandHandler
    : IRequestHandler<DeleteUserCommand>
{
    private readonly IGenericRepository<UserEntity> _repository;

    public DeleteUserCommandHandler(
        IGenericRepository<UserEntity> repository) =>
        _repository = repository;

    public async Task<Unit> Handle(
        DeleteUserCommand request,
        CancellationToken token)
    {
        if (request.Id == Guid.Empty) return Unit.Value;

        await _repository.DeleteAsync(key: request.Id, token);

        return Unit.Value;
    }
}