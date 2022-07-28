namespace WR.Microservices.UserService.Infra.IoC;

public static class DependencyInjectionConfiguration
{
    public static void RegisterServices(this IServiceCollection services)
    {
        _ = services ?? throw new ArgumentNullException(paramName: nameof(services));

        services.AddTransient<IGenericRepository<UserEntity>, GenericRepository<UserEntity>>();

        services.AddTransient<IGenericRepository<UserRoleEntity>, GenericRepository<UserRoleEntity>>();

        services.AddTransient<IUserAppService, UserAppService>();

        services.AddTransient<IUserRoleAppService, UserRoleAppService>();
    }
}