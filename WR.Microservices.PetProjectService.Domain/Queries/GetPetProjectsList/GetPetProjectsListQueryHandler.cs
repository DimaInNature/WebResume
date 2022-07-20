namespace WR.Microservices.PetProjectService.Domain.Queries;

public sealed record class GetPetProjectsListQueryHandler
    : IRequestHandler<GetPetProjectsListQuery, IEnumerable<PetProjectEntity>>
{
    private readonly IGenericRepository<PetProjectEntity> _repository;

    public GetPetProjectsListQueryHandler(
        IGenericRepository<PetProjectEntity> repository) =>
        _repository = repository;

    public async Task<IEnumerable<PetProjectEntity>> Handle(
        GetPetProjectsListQuery request,
        CancellationToken token) =>
        _repository.GetAll();
}