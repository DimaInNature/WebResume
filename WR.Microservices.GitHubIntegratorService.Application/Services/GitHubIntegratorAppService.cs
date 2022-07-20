namespace WR.Microservices.GitHubIntegratorService.Application.Services;

public class GitHubIntegratorAppService : IGitHubIntegratorAppService
{
    private readonly IMediator _mediator;

    public GitHubIntegratorAppService(IMediator mediator) => _mediator = mediator;

    public Task<IEnumerable<GitHubRepositoryResponse>> GetAllRepositoriesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<GitHubRepositoryResponse?> GetRepositoryAsync(Guid key)
    {
        throw new NotImplementedException();
    }
}