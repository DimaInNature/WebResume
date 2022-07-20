namespace WR.Microservices.PetProjectService.Domain.Queries;

public sealed record class GetPetProjectsListQuery : IRequest<IEnumerable<PetProjectEntity>>;