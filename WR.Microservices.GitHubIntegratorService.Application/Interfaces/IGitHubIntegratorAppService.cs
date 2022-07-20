namespace WR.Microservices.GitHubIntegratorService.Application.Interfaces;

public interface IGitHubIntegratorAppService
{
    Task<IEnumerable<GitHubRepositoryResponse>> GetAllRepositoriesAsync(string gitHubUsername);

    Task<GitHubRepositoryResponse?> GetRepositoryAsync(string gitHubUsername, string gitHubRepositoryName);
}