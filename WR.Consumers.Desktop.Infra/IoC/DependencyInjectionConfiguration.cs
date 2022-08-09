namespace WR.Consumers.Desktop.Infra.IoC;

public static class DependencyInjectionConfiguration
{
    public static void RegisterServices(this IServiceCollection services)
    {
        if(services is null)
            throw new ArgumentNullException(paramName: nameof(services));

        services.AddTransient<IAuthenticationAppService, AuthenticationAppService>();

        services.AddTransient<IUserAppService, UserAppService>();

        services.AddTransient<IContactMessageAppService, ContactMessageAppService>();

        services.AddTransient<IUserRoleAppService, UserRoleAppService>();
    }
}