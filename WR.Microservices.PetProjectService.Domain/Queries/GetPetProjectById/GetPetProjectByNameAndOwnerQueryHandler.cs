namespace WR.Microservices.PetProjectService.Domain.Queries;

public sealed record class GetPetProjectByNameAndOwnerQueryHandler
    : IRequestHandler<GetPetProjectByNameAndOwnerNameQuery, PetProjectEntity?>
{
    public async Task<PetProjectEntity?> Handle(
        GetPetProjectByNameAndOwnerNameQuery request, CancellationToken token)
    {
        if (string.IsNullOrWhiteSpace(value: request.OwnerName) ||
            string.IsNullOrWhiteSpace(value: request.RepositoryName))
            return null;

        HttpSender sender = new(hostUri: "https://localhost:7124");

        var result = await sender.GetAsync<PetProjectEntity>(
            routePath: $"GitHubRepositories/{request.OwnerName}/{request.RepositoryName}",
            cancellationToken: token);

        return result;
    }
}