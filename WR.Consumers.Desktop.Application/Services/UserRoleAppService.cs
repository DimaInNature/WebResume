namespace WR.Consumers.Desktop.Application.Services;

public class UserRoleAppService : IUserRoleAppService
{
    private readonly IMediator _mediator;

    public UserRoleAppService(IMediator mediator) => _mediator = mediator;

    public async Task<UserRole?> GetAsync(Guid id) =>
        await _mediator.Send(request: new GetUserRoleByIdQuery(id));

    public async Task<IEnumerable<UserRole>> GetAllAsync() =>
        await _mediator.Send(request: new GetUserRoleListQuery());

    public async Task CreateAsync(UserRole entity) =>
        await _mediator.Send(request: new CreateUserRoleCommand(entity));

    public async Task UpdateAsync(UserRole entity) =>
        await _mediator.Send(request: new UpdateUserRoleCommand(entity));

    public async Task DeleteAsync(Guid id) =>
        await _mediator.Send(request: new DeleteUserRoleCommand(id));
}