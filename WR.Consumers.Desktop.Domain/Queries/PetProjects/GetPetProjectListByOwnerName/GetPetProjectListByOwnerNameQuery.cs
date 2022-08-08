namespace WR.Consumers.Desktop.Domain.Queries.PetProjects;

public sealed record class GetPetProjectListByOwnerNameQuery
    : IRequest<IEnumerable<PetProject>>
{
    public string? OwnerName { get; }

    public GetPetProjectListByOwnerNameQuery(string ownerName) =>
        OwnerName = ownerName;

    public GetPetProjectListByOwnerNameQuery() { }
}