namespace WR.Microservices.GitHubIntegratorService.Domain.Queries;

public sealed record class GetGitHubRepositoriesListByUsernameQueryHandler
    : IRequestHandler<GetGitHubRepositoriesListByUsernameQuery, IEnumerable<GitHubRepositoryResponse>>
{
    public async Task<IEnumerable<GitHubRepositoryResponse>> Handle(
        GetGitHubRepositoriesListByUsernameQuery request,
        CancellationToken token)
    {
        using var httpClient = new HttpClient();

        httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("product", "1")); 

        httpClient.DefaultRequestHeaders.Add(name: "Accept", value: "application/vnd.github+json"); 

        using var response = await httpClient
            .GetAsync(requestUri: $"https://api.github.com/users/{request.GitHubUsername}/repos",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<List<GitHubRepositoryResponse>>(value: apiResponse) ?? new();
    }
}