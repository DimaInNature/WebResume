namespace WR.Microservices.UserService.Domain.Commands.UserRoles;

public sealed record class CreateUserRoleCommandHandler
    : IRequestHandler<CreateUserRoleCommand>
{
    private readonly IGenericRepository<UserRoleEntity> _repository;

    public CreateUserRoleCommandHandler(
        IGenericRepository<UserRoleEntity> repository) =>
        _repository = repository;

    public async Task<Unit> Handle(
        CreateUserRoleCommand request,
        CancellationToken token)
    {
        if (request.UserRole is null) return Unit.Value;

        await _repository.CreateAsync(entity: request.UserRole, token);

        return Unit.Value;
    }
}