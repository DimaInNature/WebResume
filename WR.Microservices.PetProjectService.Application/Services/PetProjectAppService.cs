namespace WR.Microservices.PetProjectService.Application.Services;

public class PetProjectAppService : IPetProjectAppService
{
    private readonly IMediator _mediator;

    public PetProjectAppService(IMediator mediator) => _mediator = mediator;

    public Task<IEnumerable<PetProjectEntity>> GetAllByOwnerNameAsync(string ownerName) =>
        _mediator.Send(request: new GetPetProjectsListByOwnerNameQuery(ownerName));

    public Task<PetProjectEntity?> GetAsync(string repositoryName, string ownerName) =>
        _mediator.Send(request: new GetPetProjectByNameAndOwnerNameQuery(repositoryName, ownerName));
}