namespace WR.Consumers.Desktop.Infra.IoC.MediatR.Profiles;

public static class AuthMediatRProfile
{
    public static void AddAuthMediatRProfile(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        #region Commands

        services.AddScoped<IRequest<string?>, UserAuthorizationCommand>();
        services.AddScoped<IRequestHandler<UserAuthorizationCommand, string?>, UserAuthorizationCommandHandler>();

        #endregion
    }
}