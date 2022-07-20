namespace WR.Microservices.GitHubIntegratorService.Infra.IoC;

public static class DependencyInjectionConfiguration
{
    public static void RegisterServices(this IServiceCollection services)
    {
        _ = services ?? throw new ArgumentNullException(paramName: nameof(services));

        services.AddTransient<IAsyncCacheRepository<GitHubRepositoryResponse>, RedisCacheRepository<GitHubRepositoryResponse>>();

        services.AddTransient<IGitHubIntegratorAppService, GitHubIntegratorAppService>();

        services.Decorate<IGitHubIntegratorAppService, GitHubIntegratorAppCachingService>();

        services.Decorate<IGitHubIntegratorAppService, GitHubIntegratorAppLoggerService>();
    }
}