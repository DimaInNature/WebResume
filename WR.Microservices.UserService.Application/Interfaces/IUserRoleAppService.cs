namespace WR.Microservices.UserService.Application.Interfaces;

public interface IUserRoleAppService
{
    Task<IEnumerable<UserRoleEntity>> GetAllAsync();

    Task<IEnumerable<UserRoleEntity>> GetAllAsync(Func<UserRoleEntity, bool> predicate);

    Task<UserRoleEntity?> GetAsync(Guid id);

    Task<UserRoleEntity?> GetAsync(Func<UserRoleEntity, bool> predicate);

    Task CreateAsync(UserRoleEntity entity);

    Task UpdateAsync(UserRoleEntity entity);

    Task DeleteAsync(Guid id);
}