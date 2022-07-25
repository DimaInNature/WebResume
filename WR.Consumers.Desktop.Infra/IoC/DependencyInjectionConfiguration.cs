namespace WR.Consumers.Desktop.Infra.IoC;

public static class DependencyInjectionConfiguration
{
    public static void RegisterServices(this IServiceCollection services)
    {
        _ = services ?? throw new ArgumentNullException(paramName: nameof(services));

        services.AddTransient<IAuthenticationAppService, AuthenticationAppService>();

        services.AddTransient<IUserAppService, UserAppService>();

        services.AddTransient<IContactMessageAppService, ContactMessageAppService>();
    }

    public static void AddViewModelsConfiguration(this IServiceCollection services)
    {
        if (services is null) throw new ArgumentNullException(nameof(services));

        services.Scan(action: scan =>
            scan.FromAssemblyOf<BaseViewModel>()
        .AddClasses(action: classes =>
            classes.Where(predicate: type =>
                type.Name.EndsWith(value: "ViewModel"))));
    }
}