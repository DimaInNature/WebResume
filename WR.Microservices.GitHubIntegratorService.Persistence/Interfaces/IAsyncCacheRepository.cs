namespace WR.Microservices.GitHubIntegratorService.Persistence.Interfaces;

public interface IAsyncCacheRepository<T> where T : class
{
    public Task<T?> GetAsync(string key);
    public Task<bool> SetAsync(string key, T? value);
    public Task<bool> RemoveAsync(string key);
}