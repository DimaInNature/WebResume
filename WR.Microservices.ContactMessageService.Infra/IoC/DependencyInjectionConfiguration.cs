namespace WR.Microservices.ContactMessageService.Infra.IoC;

public static class DependencyInjectionConfiguration
{
    public static void RegisterServices(this IServiceCollection services)
    {
        _ = services ?? throw new ArgumentNullException(paramName: nameof(services));

        services.AddTransient<IGenericRepository<ContactMessageEntity>, GenericRepository<ContactMessageEntity>>();

        services.AddTransient<IContactMessageAppService, ContactMessageAppService>();
    }
}