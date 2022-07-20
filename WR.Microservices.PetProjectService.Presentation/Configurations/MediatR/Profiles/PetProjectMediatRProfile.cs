namespace WR.Microservices.PetProjectService.Presentation.Configurations.MediatR.Profiles;

public static class PetProjectMediatRProfile
{
    public static void AddPetProjectMediatRProfile(this IServiceCollection services)
    {
        #region Queries

        services.AddScoped<IRequest<IEnumerable<PetProjectEntity>>, GetPetProjectsListQuery>();
        services.AddScoped<IRequestHandler<GetPetProjectsListQuery, IEnumerable<PetProjectEntity>>, GetPetProjectsListQueryHandler>();

        services.AddScoped<IRequest<PetProjectEntity?>, GetPetProjectByIdQuery>();
        services.AddScoped<IRequestHandler<GetPetProjectByIdQuery, PetProjectEntity?>, GetPetProjectByIdQueryHandler>();

        #endregion
    }
}