namespace WR.Microservices.UserService.Infra.IoC.MediatR.Profiles;

public static class UserRoleMediatRProfile
{
    public static void AddUserRoleMediatRProfile(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        #region Commands

        services.AddScoped<IRequest<Unit>, CreateUserRoleCommand>();
        services.AddScoped<IRequestHandler<CreateUserRoleCommand, Unit>, CreateUserRoleCommandHandler>();

        services.AddScoped<IRequest<Unit>, UpdateUserRoleCommand>();
        services.AddScoped<IRequestHandler<UpdateUserRoleCommand, Unit>, UpdateUserRoleCommandHandler>();

        services.AddScoped<IRequest<Unit>, DeleteUserRoleCommand>();
        services.AddScoped<IRequestHandler<DeleteUserRoleCommand, Unit>, DeleteUserRoleCommandHandler>();

        #endregion

        #region Queries

        services.AddScoped<IRequest<UserRoleEntity?>, GetUserRoleByPredicateQuery>();
        services.AddScoped<IRequestHandler<GetUserRoleByPredicateQuery, UserRoleEntity?>, GetUserRoleByPredicateQueryHandler>();

        services.AddScoped<IRequest<IEnumerable<UserRoleEntity>>, GetUserRolesListQuery>();
        services.AddScoped<IRequestHandler<GetUserRolesListQuery, IEnumerable<UserRoleEntity>>, GetUserRolesListQueryHandler>();

        services.AddScoped<IRequest<IEnumerable<UserRoleEntity>>, GetUserRolesListByPredicateQuery>();
        services.AddScoped<IRequestHandler<GetUserRolesListByPredicateQuery, IEnumerable<UserRoleEntity>>, GetUserRolesListByPredicateQueryHandler>();

        #endregion
    }
}