namespace WR.Microservices.PetProjectService.Domain.Queries;

public sealed record class GetPetProjectByNameAndOwnerNameQuery
    : IRequest<PetProjectEntity?>
{
    public string? RepositoryName { get; }

    public string? OwnerName { get; }

    public GetPetProjectByNameAndOwnerNameQuery(string repositoryName, string ownerName) =>
        (RepositoryName, OwnerName) = (repositoryName, ownerName);

    public GetPetProjectByNameAndOwnerNameQuery() { }
}