namespace WR.Microservices.GitHubIntegratorService.Application.Services.Decorators;

public class GitHubIntegratorAppCachingService : IGitHubIntegratorAppService
{
    private const string NameForCaching = "GitHubRepository";

    private readonly IAsyncCacheRepository<GitHubRepositoryResponse> _gitHubRepositoryCache;

    private readonly IGitHubIntegratorAppService _gitHubIntegratorAppService;

    public GitHubIntegratorAppCachingService(
        IAsyncCacheRepository<GitHubRepositoryResponse> gitHubRepositoryCache,
        IGitHubIntegratorAppService gitHubIntegratorAppService) =>
        (_gitHubRepositoryCache, _gitHubIntegratorAppService) = (gitHubRepositoryCache, gitHubIntegratorAppService);

    public async Task<IEnumerable<GitHubRepositoryResponse>> GetAllRepositoriesAsync(string gitHubUsername) =>
        await _gitHubIntegratorAppService.GetAllRepositoriesAsync(gitHubUsername);

    public async Task<GitHubRepositoryResponse?> GetRepositoryAsync(string gitHubUsername, string gitHubRepositoryName)
    {
        var gitHubRepositoryFromCache = await _gitHubRepositoryCache.GetAsync(key: $"{NameForCaching}/{gitHubUsername}/{gitHubRepositoryName}");

        if (gitHubRepositoryFromCache is not null) return gitHubRepositoryFromCache;

        var gitHubRepositoryFromAPI = await _gitHubIntegratorAppService.GetRepositoryAsync(gitHubUsername, gitHubRepositoryName);

        if(gitHubRepositoryFromAPI is null) return null;

        await _gitHubRepositoryCache.SetAsync(
            key: $"{NameForCaching}/{gitHubUsername}/{gitHubRepositoryName}",
            value: gitHubRepositoryFromAPI);

        return gitHubRepositoryFromAPI;
    }
}
