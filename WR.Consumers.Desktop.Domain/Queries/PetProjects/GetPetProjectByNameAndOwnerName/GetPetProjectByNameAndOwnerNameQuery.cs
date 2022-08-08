namespace WR.Consumers.Desktop.Domain.Queries.PetProjects;

public sealed record class GetPetProjectByNameAndOwnerNameQuery
    : IRequest<PetProject?>
{
    public string? Name { get; }

    public string? OwnerName { get; }

    public GetPetProjectByNameAndOwnerNameQuery(
        string name, string ownerName) =>
        (Name, OwnerName) = (name, ownerName);

    public GetPetProjectByNameAndOwnerNameQuery() { }
}