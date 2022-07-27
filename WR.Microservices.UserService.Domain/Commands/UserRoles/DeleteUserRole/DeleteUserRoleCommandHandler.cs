namespace WR.Microservices.UserService.Domain.Commands.UserRoles;

public sealed record class DeleteUserRoleCommandHandler
    : IRequestHandler<DeleteUserRoleCommand>
{
    private readonly IGenericRepository<UserRoleEntity> _repository;

    public DeleteUserRoleCommandHandler(
        IGenericRepository<UserRoleEntity> repository) =>
        _repository = repository;   

    public async Task<Unit> Handle(
        DeleteUserRoleCommand request,
        CancellationToken token)
    {
        if (request.Id == Guid.Empty) return Unit.Value;

        await _repository.DeleteAsync(key: request.Id, token);

        return Unit.Value;
    }
}