namespace WR.Consumers.Desktop.Infra.IoC.MediatR.Profiles;

public static class UserRoleMediatRProfile
{
    public static void AddUserRoleMediatRProfile(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        #region Queries

        services.AddScoped<IRequest<IEnumerable<UserRole>>, GetUserRoleListQuery>();
        services.AddScoped<IRequestHandler<GetUserRoleListQuery, IEnumerable<UserRole>>, GetUserRoleListQueryHandler>();

        services.AddScoped<IRequest<UserRole?>, GetUserRoleByIdQuery>();
        services.AddScoped<IRequestHandler<GetUserRoleByIdQuery, UserRole?>, GetUserRoleByIdQueryHandler>();

        #endregion

        #region Commands

        services.AddScoped<IRequest<Unit>, CreateUserRoleCommand>();
        services.AddScoped<IRequestHandler<CreateUserRoleCommand, Unit>, CreateUserRoleCommandHandler>();

        services.AddScoped<IRequest<Unit>, UpdateUserRoleCommand>();
        services.AddScoped<IRequestHandler<UpdateUserRoleCommand, Unit>, UpdateUserRoleCommandHandler>();

        services.AddScoped<IRequest<Unit>, DeleteUserRoleCommand>();
        services.AddScoped<IRequestHandler<DeleteUserRoleCommand, Unit>, DeleteUserRoleCommandHandler>();

        #endregion
    }
}