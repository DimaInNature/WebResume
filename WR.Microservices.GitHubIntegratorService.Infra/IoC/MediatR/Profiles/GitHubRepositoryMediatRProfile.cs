namespace WR.Microservices.GitHubIntegratorService.Infra.IoC.MediatR.Profiles;

public static class GitHubRepositoryMediatRProfile
{
    public static void AddGitHubRepositoryMediatRProfile(this IServiceCollection services)
    {
        #region Queries

        services.AddScoped<IRequest<IEnumerable<GitHubRepositoryResponse>>, GetGitHubRepositoriesListByUsernameQuery>();
        services.AddScoped<IRequestHandler<GetGitHubRepositoriesListByUsernameQuery, IEnumerable<GitHubRepositoryResponse>>, GetGitHubRepositoriesListByUsernameQueryHandler>();

        services.AddScoped<IRequest<GitHubRepositoryResponse?>, GetGitHubRepositoryByNameQuery>();
        services.AddScoped<IRequestHandler<GetGitHubRepositoryByNameQuery, GitHubRepositoryResponse?>, GetGitHubRepositoryByNameQueryHandler>();

        #endregion
    }
}