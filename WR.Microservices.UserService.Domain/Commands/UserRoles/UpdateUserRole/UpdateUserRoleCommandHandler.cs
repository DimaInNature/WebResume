namespace WR.Microservices.UserService.Domain.Commands.UserRoles;

public sealed record class UpdateUserRoleCommandHandler
    : IRequestHandler<UpdateUserRoleCommand>
{
    private readonly IGenericRepository<UserRoleEntity> _repository;

    public UpdateUserRoleCommandHandler(
        IGenericRepository<UserRoleEntity> repository) =>
        _repository = repository;

    public async Task<Unit> Handle(
        UpdateUserRoleCommand request,
        CancellationToken token)
    {
        if (request.UserRole is null) return Unit.Value;

        await _repository.UpdateAsync(entity: request.UserRole, token);

        return Unit.Value;
    }
}