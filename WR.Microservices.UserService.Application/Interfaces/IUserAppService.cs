namespace WR.Microservices.UserService.Application.Interfaces;

public interface IUserAppService
{
    Task<IEnumerable<UserEntity>> GetAllAsync();

    Task<UserEntity?> GetAsync(Guid key);

    Task CreateAsync(UserEntity entity);

    Task UpdateAsync(UserEntity entity);

    Task DeleteAsync(Guid key);
}