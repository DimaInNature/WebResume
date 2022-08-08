namespace WR.Consumers.Desktop.Infra.IoC.MediatR.Profiles;

internal static class UserMediatRProfile
{
    public static void AddUserMediatRProfile(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        #region Queries

        services.AddScoped<IRequest<IEnumerable<User>>, GetUserListQuery>();
        services.AddScoped<IRequestHandler<GetUserListQuery, IEnumerable<User>>, GetUserListQueryHandler>();

        services.AddScoped<IRequest<User?>, GetUserByIdQuery>();
        services.AddScoped<IRequestHandler<GetUserByIdQuery, User?>, GetUserByIdQueryHandler>();

        services.AddScoped<IRequest<User?>, GetUserByLoginAndPasswordQuery>();
        services.AddScoped<IRequestHandler<GetUserByLoginAndPasswordQuery, User?>, GetUserByLoginAndPasswordQueryHandler>();

        #endregion

        #region Commands

        services.AddScoped<IRequest<Unit>, CreateUserCommand>();
        services.AddScoped<IRequestHandler<CreateUserCommand, Unit>, CreateUserCommandHandler>();

        services.AddScoped<IRequest<Unit>, UpdateUserCommand>();
        services.AddScoped<IRequestHandler<UpdateUserCommand, Unit>, UpdateUserCommandHandler>();

        services.AddScoped<IRequest<Unit>, DeleteUserCommand>();
        services.AddScoped<IRequestHandler<DeleteUserCommand, Unit>, DeleteUserCommandHandler>();

        #endregion
    }
}