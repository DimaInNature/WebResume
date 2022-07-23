namespace WR.Microservices.PetProjectService.Presentation.Configurations.MediatR.Profiles;

public static class PetProjectMediatRProfile
{
    public static void AddPetProjectMediatRProfile(this IServiceCollection services)
    {
        #region Queries

        services.AddScoped<IRequest<IEnumerable<PetProjectEntity>>, GetPetProjectsListByOwnerNameQuery>();
        services.AddScoped<IRequestHandler<GetPetProjectsListByOwnerNameQuery, IEnumerable<PetProjectEntity>>, GetPetProjectsListByOwnerNameQueryHandler>();

        services.AddScoped<IRequest<PetProjectEntity?>, GetPetProjectByNameAndOwnerNameQuery>();
        services.AddScoped<IRequestHandler<GetPetProjectByNameAndOwnerNameQuery, PetProjectEntity?>, GetPetProjectByNameAndOwnerQueryHandler>();

        #endregion
    }
}