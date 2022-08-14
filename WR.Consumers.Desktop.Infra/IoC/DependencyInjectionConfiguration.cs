namespace WR.Consumers.Desktop.Infra.IoC;

public static class DependencyInjectionConfiguration
{
    public static void RegisterServices(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: nameof(services));

        services.AddSingleton<UserSessionService>();

        services.AddTransient<IAuthenticationAppService, JWTAuthenticationAppService>();

        services.AddTransient<IUserAppService, UserAppService>();

        services.AddTransient<IContactMessageAppService, ContactMessageAppService>();

        services.AddTransient<IUserRoleAppService, UserRoleAppService>();

        services.AddTransient<IPetProjectAppService, PetProjectAppService>();
    }
}