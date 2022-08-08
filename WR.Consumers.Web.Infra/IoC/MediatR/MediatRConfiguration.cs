﻿namespace WR.Consumers.Web.Infra.IoC.MediatR;

public static class MediatRConfiguration
{
    public static void AddMediatRConfiguration(this IServiceCollection services)
    {
        services.AddMediatR(assemblies: Assembly.GetExecutingAssembly());

        // Add features: ...

        services.AddContactMessageMediatRProfile();

        services.AddPetProjectMediatRProfile();
    }
}