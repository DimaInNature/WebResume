namespace WR.Microservices.AuthenticationService.Infra.IoC.MediatR.Profiles;

public static class UserMediatRProfile
{
    public static void AddUserMediatRProfile(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        services.AddScoped<IRequest<User?>, GetUserByLoginAndPasswordQuery>();
        services.AddScoped<IRequestHandler<GetUserByLoginAndPasswordQuery, User?>, GetUserByLoginAndPasswordQueryHandler>();
    }
}