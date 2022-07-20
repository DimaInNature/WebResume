namespace WR.Microservices.GitHubIntegratorService.Domain.Queries;

public sealed record class GetGitHubRepositoryByNameQuery : IRequest<GitHubRepositoryResponse?>
{
    public string? GitHubUsername { get; } = null;

	public string? GitHubRepositoryName { get; } = null;

	public GetGitHubRepositoryByNameQuery(string gitHubUsername, string gitHubRepositoryName) =>
		(GitHubUsername, GitHubRepositoryName) = (gitHubUsername, gitHubRepositoryName);

	public GetGitHubRepositoryByNameQuery() { }
}
