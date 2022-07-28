﻿namespace WR.Microservices.UserService.Infra.IoC.MediatR;

public static class MediatRConfiguration
{
    public static void AddMediatRConfiguration(this IServiceCollection services)
    {
        services.AddMediatR(assemblies: Assembly.GetExecutingAssembly());

        services.AddUserMediatRProfile();

        services.AddUserRoleMediatRProfile();
    }
}