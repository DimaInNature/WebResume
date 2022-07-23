namespace WR.Microservices.PetProjectService.Domain.Queries;

public sealed record class GetPetProjectsListByOwnerNameQuery : IRequest<IEnumerable<PetProjectEntity>>
{
    public string? OwnerName { get; }

    public GetPetProjectsListByOwnerNameQuery(string ownerName) => OwnerName = ownerName;

    public GetPetProjectsListByOwnerNameQuery() { }
}