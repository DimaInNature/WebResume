namespace WR.Microservices.UserService.Application.Services;

public class UserRoleAppService : IUserRoleAppService
{
    private readonly IMediator _mediator;

    public UserRoleAppService(IMediator mediator) => _mediator = mediator;

    public async Task<IEnumerable<UserRoleEntity>> GetAllAsync() =>
        await _mediator.Send(request: new GetUserRolesListQuery());

    public async Task<IEnumerable<UserRoleEntity>> GetAllAsync(
        Func<UserRoleEntity, bool> predicate) =>
        await _mediator.Send(request: new GetUserRolesListByPredicateQuery(predicate));

    public async Task<UserRoleEntity?> GetAsync(Guid id) =>
        await _mediator.Send(
            request: new GetUserRoleByPredicateQuery(
                predicate: userRole => userRole.Id == id));

    public async Task<UserRoleEntity?> GetAsync(
        Func<UserRoleEntity, bool> predicate) =>
        await _mediator.Send(
            request: new GetUserRoleByPredicateQuery(predicate));

    public async Task CreateAsync(UserRoleEntity entity) =>
        await _mediator.Send(request: new CreateUserRoleCommand(entity));

    public async Task UpdateAsync(UserRoleEntity entity) =>
        await _mediator.Send(request: new UpdateUserRoleCommand(entity));

    public async Task DeleteAsync(Guid id) =>
        await _mediator.Send(request: new DeleteUserCommand(id));
}