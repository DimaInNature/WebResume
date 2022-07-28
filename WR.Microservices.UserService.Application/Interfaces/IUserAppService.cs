namespace WR.Microservices.UserService.Application.Interfaces;

public interface IUserAppService
{
    Task<IEnumerable<UserEntity>> GetAllAsync();

    Task<IEnumerable<UserEntity>> GetAllAsync(Func<UserEntity, bool> predicate);

    Task<UserEntity?> GetAsync(Guid id);

    Task<UserEntity?> GetAsync(Func<UserEntity, bool> predicate);

    Task CreateAsync(UserEntity entity);

    Task UpdateAsync(UserEntity entity);

    Task DeleteAsync(Guid id);
}