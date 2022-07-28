namespace WR.Microservices.UserService.Infra.IoC.MediatR.Profiles;

public static class UserMediatRProfile
{
    public static void AddUserMediatRProfile(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        #region Commands

        services.AddScoped<IRequest<Unit>, CreateUserCommand>();
        services.AddScoped<IRequestHandler<CreateUserCommand, Unit>, CreateUserCommandHandler>();

        services.AddScoped<IRequest<Unit>, UpdateUserCommand>();
        services.AddScoped<IRequestHandler<UpdateUserCommand, Unit>, UpdateUserCommandHandler>();

        services.AddScoped<IRequest<Unit>, DeleteUserCommand>();
        services.AddScoped<IRequestHandler<DeleteUserCommand, Unit>, DeleteUserCommandHandler>();

        #endregion

        #region Queries

        services.AddScoped<IRequest<UserEntity?>, GetUserByPredicateQuery>();
        services.AddScoped<IRequestHandler<GetUserByPredicateQuery, UserEntity?>, GetUserByPredicateQueryHandler>();

        services.AddScoped<IRequest<IEnumerable<UserEntity>>, GetUsersListQuery>();
        services.AddScoped<IRequestHandler<GetUsersListQuery, IEnumerable<UserEntity>>, GetUsersListQueryHandler>();

        services.AddScoped<IRequest<IEnumerable<UserEntity>>, GetUsersListByPredicateQuery>();
        services.AddScoped<IRequestHandler<GetUsersListByPredicateQuery, IEnumerable<UserEntity>>, GetUsersListByPredicateQueryHandler>();

        #endregion
    }
}