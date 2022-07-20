namespace WR.Microservices.GitHubIntegratorService.Infra.IoC;

public static class RedisConfiguration
{
    public static void AddRedisConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IConnectionMultiplexer>(
            implementationFactory: x => ConnectionMultiplexer.Connect(
                configuration: configuration[key: "RedisConnection"]));
    }
}