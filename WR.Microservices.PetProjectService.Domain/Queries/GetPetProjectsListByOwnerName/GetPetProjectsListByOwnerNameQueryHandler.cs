namespace WR.Microservices.PetProjectService.Domain.Queries;

public sealed record class GetPetProjectsListByOwnerNameQueryHandler
    : IRequestHandler<GetPetProjectsListByOwnerNameQuery, IEnumerable<PetProjectEntity>>
{
    public async Task<IEnumerable<PetProjectEntity>> Handle(
        GetPetProjectsListByOwnerNameQuery request,
        CancellationToken token)
    {
        if (string.IsNullOrWhiteSpace(value: request.OwnerName)) return new List<PetProjectEntity>();

        HttpSender sender = new(hostUri: "https://localhost:7124");

        var result = await sender.GetAsync<IEnumerable<PetProjectEntity>>(
            routePath: $"GitHubRepositories/Users/{request.OwnerName}/Repositories",
            cancellationToken: token);

        return result ?? new List<PetProjectEntity>();
    }
}