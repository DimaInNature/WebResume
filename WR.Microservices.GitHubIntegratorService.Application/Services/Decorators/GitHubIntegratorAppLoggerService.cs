namespace WR.Microservices.GitHubIntegratorService.Application.Services.Decorators;

public sealed class GitHubIntegratorAppLoggerService : IGitHubIntegratorAppService
{
    private readonly ILogger<GitHubIntegratorAppLoggerService> _logger;

    private readonly IGitHubIntegratorAppService _gitHubIntegratorAppService;

    public GitHubIntegratorAppLoggerService(
        ILogger<GitHubIntegratorAppLoggerService> logger,
        IGitHubIntegratorAppService gitHubIntegratorAppService) =>
        (_logger, _gitHubIntegratorAppService) = (logger, gitHubIntegratorAppService);

    public async Task<IEnumerable<GitHubRepositoryResponse>> GetAllRepositoriesAsync(string gitHubUsername)
    {
        try
        {
            return await _gitHubIntegratorAppService.GetAllRepositoriesAsync(gitHubUsername);
        }
        catch (Exception ex)
        {
            _logger.LogError(message: ex.Message);

            return new List<GitHubRepositoryResponse>();
        }
    }

    public async Task<GitHubRepositoryResponse?> GetRepositoryAsync(string gitHubUsername, string gitHubRepositoryName)
    {
        try
        {
            return await _gitHubIntegratorAppService.GetRepositoryAsync(gitHubUsername, gitHubRepositoryName);
        }
        catch (Exception ex)
        {
            _logger.LogError(message: ex.Message);

            return null;
        }
    }
}
