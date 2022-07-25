namespace WR.Consumers.Desktop.Application.Services;

public class UserAppService : IUserAppService
{
    private readonly IMediator _mediator;

    public UserAppService(IMediator mediator) => _mediator = mediator;

    public Task<User?> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}