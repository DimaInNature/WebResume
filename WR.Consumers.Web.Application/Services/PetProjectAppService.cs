namespace WR.Consumers.Web.Application.Services;

public sealed class PetProjectAppService : IPetProjectAppService
{
    private readonly IMediator _mediator;

    public PetProjectAppService(IMediator mediator) => _mediator = mediator;

    public async Task<IEnumerable<PetProject>> GetAllAsync(string ownerName) =>
        await _mediator.Send(request: new GetPetProjectListByOwnerNameQuery(ownerName));

    public async Task<PetProject?> GetAsync(string repositoryName, string ownerName) =>
        await _mediator.Send(request: new GetPetProjectByNameAndOwnerNameQuery(name: repositoryName, ownerName));
}