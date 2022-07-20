namespace WR.Microservices.GitHubIntegratorService.Domain.Queries;

public sealed record class GetGitHubRepositoriesListByUsernameQuery 
	: IRequest<IEnumerable<GitHubRepositoryResponse>>
{
    public string? GitHubUsername { get; } = null;

	public GetGitHubRepositoriesListByUsernameQuery(string gitHubUserName) => GitHubUsername = gitHubUserName;

	public GetGitHubRepositoriesListByUsernameQuery() { }
}