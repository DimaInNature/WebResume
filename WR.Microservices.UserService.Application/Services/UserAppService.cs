namespace WR.Microservices.UserService.Application.Services;

public class UserAppService : IUserAppService
{
    private readonly IMediator _mediator;

    public UserAppService(IMediator mediator) => _mediator = mediator;

    public async Task<IEnumerable<UserEntity>> GetAllAsync() =>
        await _mediator.Send(request: new GetUsersListQuery());

    public async Task<IEnumerable<UserEntity>> GetAllAsync(
        Func<UserEntity, bool> predicate) =>
        await _mediator.Send(request: new GetUsersListByPredicateQuery(predicate));

    public async Task<UserEntity?> GetAsync(Guid id) =>
      await _mediator.Send(
          request: new GetUserByPredicateQuery(
              predicate: user => user.Id == id));

    public async Task<UserEntity?> GetAsync(
        Func<UserEntity, bool> predicate) =>
        await _mediator.Send(request: new GetUserByPredicateQuery(predicate));

    public async Task CreateAsync(UserEntity entity) =>
        await _mediator.Send(request: new CreateUserCommand(entity));

    public async Task UpdateAsync(UserEntity entity) =>
        await _mediator.Send(request: new UpdateUserCommand(entity));

    public async Task DeleteAsync(Guid id) =>
        await _mediator.Send(request: new DeleteUserCommand(id));
}