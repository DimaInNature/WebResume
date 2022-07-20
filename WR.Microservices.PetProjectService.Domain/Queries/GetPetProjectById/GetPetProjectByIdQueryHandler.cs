namespace WR.Microservices.PetProjectService.Domain.Queries;

public sealed record class GetPetProjectByIdQueryHandler
    : IRequestHandler<GetPetProjectByIdQuery, PetProjectEntity?>
{
    private readonly IGenericRepository<PetProjectEntity> _repository;

    public GetPetProjectByIdQueryHandler(
        IGenericRepository<PetProjectEntity> repository) =>
        _repository = repository;

    public async Task<PetProjectEntity?> Handle(
        GetPetProjectByIdQuery request, CancellationToken token) =>
        request.Key == Guid.Empty
        ? default
        : await _repository.GetFirstOrDefaultAsync(key: request.Key, token);
}