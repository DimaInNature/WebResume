namespace WR.Consumers.Desktop.Application.Interfaces;

public interface IUserAppService
{
    public Task<User?> GetAsync(Guid id);

    public Task<User?> GetAsync(string username, string password);

    public Task<IEnumerable<User>> GetAllAsync();

    public Task CreateAsync(User entity);

    public Task UpdateAsync(User entity);

    public Task DeleteAsync(Guid id);
}