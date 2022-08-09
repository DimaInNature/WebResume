namespace WR.Consumers.Desktop.Application.Interfaces;

public interface IUserRoleAppService
{
    public Task<UserRole?> GetAsync(Guid id);

    public Task<IEnumerable<UserRole>> GetAllAsync();

    public Task CreateAsync(UserRole entity);

    public Task UpdateAsync(UserRole entity);

    public Task DeleteAsync(Guid id);
}