namespace WR.Microservices.PetProjectService.Domain.Queries;

public sealed record class GetPetProjectByIdQuery
    : IRequest<PetProjectEntity?>
{
    public Guid Key { get; }

    public GetPetProjectByIdQuery(Guid key) => Key = key;

    public GetPetProjectByIdQuery() { }
}