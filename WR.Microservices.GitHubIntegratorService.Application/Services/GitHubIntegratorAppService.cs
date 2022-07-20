namespace WR.Microservices.GitHubIntegratorService.Application.Services;

public class GitHubIntegratorAppService : IGitHubIntegratorAppService
{
    private readonly IMediator _mediator;

    public GitHubIntegratorAppService(IMediator mediator) => _mediator = mediator;

    public async Task<IEnumerable<GitHubRepositoryResponse>> GetAllRepositoriesAsync(string gitHubUsername) =>
        await _mediator.Send(request: new GetGitHubRepositoriesListByUsernameQuery(gitHubUsername));

    public async Task<GitHubRepositoryResponse?> GetRepositoryAsync(string gitHubUsername, string gitHubRepositoryName) =>
        await _mediator.Send(request: new GetGitHubRepositoryByNameQuery(gitHubUsername, gitHubRepositoryName));
}