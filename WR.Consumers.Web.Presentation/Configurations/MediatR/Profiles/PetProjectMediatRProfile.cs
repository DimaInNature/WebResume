namespace WR.Consumers.Web.Presentation.Configurations.MediatR.Profiles;

public static class PetProjectMediatRProfile
{
    public static void AddPetProjectMediatRProfile(this IServiceCollection services)
    {
        #region Queries

        services.AddScoped<IRequest<IEnumerable<PetProject>>, GetPetProjectListByOwnerNameQuery>();
        services.AddScoped<IRequestHandler<GetPetProjectListByOwnerNameQuery, IEnumerable<PetProject>>, GetPetProjectListByOwnerNameQueryHandler>();

        services.AddScoped<IRequest<PetProject?>, GetPetProjectByNameAndOwnerNameQuery>();
        services.AddScoped<IRequestHandler<GetPetProjectByNameAndOwnerNameQuery, PetProject?>, GetPetProjectByNameAndOwnerNameQueryHandler>();

        #endregion
    }
}