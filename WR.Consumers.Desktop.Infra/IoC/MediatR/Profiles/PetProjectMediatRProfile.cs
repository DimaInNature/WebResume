namespace WR.Consumers.Desktop.Infra.IoC.MediatR.Profiles;

public static class PetProjectMediatRProfile
{
    public static void AddPetProjectMediatRProfile(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        #region Queries

        services.AddScoped<IRequest<PetProject?>, GetPetProjectByNameAndOwnerNameQuery>();
        services.AddScoped<IRequestHandler<GetPetProjectByNameAndOwnerNameQuery, PetProject?>, GetPetProjectByNameAndOwnerNameQueryHandler>();

        services.AddScoped<IRequest<IEnumerable<PetProject>>, GetPetProjectListByOwnerNameQuery>();
        services.AddScoped<IRequestHandler<GetPetProjectListByOwnerNameQuery, IEnumerable<PetProject>>, GetPetProjectListByOwnerNameQueryHandler>();

        #endregion
    }
}