namespace WR.Microservices.PetProjectService.Application.Services;

public class PetProjectAppService : IPetProjectAppService
{
    private readonly IMediator _mediator;

    public PetProjectAppService(IMediator mediator) => _mediator = mediator;

    public Task<IEnumerable<PetProjectEntity>> GetAllAsync() =>
        _mediator.Send(request: new GetPetProjectsListQuery());

    public Task<PetProjectEntity?> GetAsync(Guid key) =>
        _mediator.Send(request: new GetPetProjectByIdQuery(key));
}