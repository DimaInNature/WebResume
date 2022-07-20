namespace WR.Microservices.GitHubIntegratorService.Application.Interfaces;

public interface IGitHubIntegratorAppService
{
    Task<IEnumerable<GitHubRepositoryResponse>> GetAllRepositoriesAsync();

    Task<GitHubRepositoryResponse?> GetRepositoryAsync(Guid key);
}