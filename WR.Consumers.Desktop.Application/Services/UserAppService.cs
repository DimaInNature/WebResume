namespace WR.Consumers.Desktop.Application.Services;

public class UserAppService : IUserAppService
{
    private readonly IMediator _mediator;

    public UserAppService(IMediator mediator) => _mediator = mediator;

    public async Task<User?> GetAsync(Guid id) =>
        await _mediator.Send(request: new GetUserByIdQuery(id));

    public async Task<User?> GetAsync(string username, string password) =>
        await _mediator.Send(request: new GetUserByLoginAndPasswordQuery(username, password));

    public async Task<IEnumerable<User>> GetAllAsync() =>
        await _mediator.Send(request: new GetUserListQuery());

    public async Task CreateAsync(User entity) =>
        await _mediator.Send(request: new CreateUserCommand(entity));

    public async Task UpdateAsync(User entity) =>
        await _mediator.Send(request: new UpdateUserCommand(entity));

    public async Task DeleteAsync(Guid id) =>
        await _mediator.Send(request: new DeleteUserCommand(id));
}