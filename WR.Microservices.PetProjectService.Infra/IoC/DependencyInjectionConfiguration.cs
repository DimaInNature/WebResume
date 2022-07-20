namespace WR.Microservices.PetProjectService.Infra.IoC;

public static class DependencyInjectionConfiguration
{
    public static void RegisterServices(this IServiceCollection services)
    {
        _ = services ?? throw new ArgumentNullException(paramName: nameof(services));

        services.AddTransient<IGenericRepository<PetProjectEntity>, GenericRepository<PetProjectEntity>>();

        services.AddTransient<IPetProjectAppService, PetProjectAppService>();
    }
}