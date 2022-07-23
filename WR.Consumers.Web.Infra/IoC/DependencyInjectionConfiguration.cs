namespace WR.Consumers.Web.Infra.IoC;

public static class DependencyInjectionConfiguration
{
    public static void RegisterServices(this IServiceCollection services)
    {
        _ = services ?? throw new ArgumentNullException(paramName: nameof(services));

        services.AddTransient<IContactMessageAppService, ContactMessageAppService>();

        services.AddTransient<IPetProjectAppService, PetProjectAppService>();
    }
}