namespace WR.Microservices.GitHubIntegratorService.Presentation.Configurations.MediatR;

public static class MediatRConfiguration
{
    public static void AddMediatRConfiguration(this IServiceCollection services)
    {
        services.AddMediatR(assemblies: Assembly.GetExecutingAssembly());

        // Add features: ...

        services.AddGitHubRepositoryMediatRProfile();
    }
}