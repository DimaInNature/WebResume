namespace WR.Microservices.GitHubIntegratorService.Domain.Queries;

public sealed record class GetGitHubRepositoryByNameQueryHandler
    : IRequestHandler<GetGitHubRepositoryByNameQuery, GitHubRepositoryResponse?>
{
    public async Task<GitHubRepositoryResponse?> Handle(
        GetGitHubRepositoryByNameQuery request,
        CancellationToken token)
    {
        using var httpClient = new HttpClient();

        httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("product", "1"));

        httpClient.DefaultRequestHeaders.Add(name: "Accept", value: "application/vnd.github+json");

        using var response = await httpClient
            .GetAsync(requestUri: $"https://api.github.com/repos/{request.GitHubUsername}/{request.GitHubRepositoryName}",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<GitHubRepositoryResponse>(value: apiResponse);
    }
}