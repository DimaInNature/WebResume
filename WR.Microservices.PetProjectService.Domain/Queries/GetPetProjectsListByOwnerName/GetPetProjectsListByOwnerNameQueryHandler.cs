namespace WR.Microservices.PetProjectService.Domain.Queries;

public sealed record class GetPetProjectsListByOwnerNameQueryHandler
    : IRequestHandler<GetPetProjectsListByOwnerNameQuery, IEnumerable<PetProjectEntity>>
{
    private readonly IConfiguration _configuration;

    public GetPetProjectsListByOwnerNameQueryHandler(IConfiguration configuration) =>
        _configuration = configuration;

    public async Task<IEnumerable<PetProjectEntity>> Handle(
        GetPetProjectsListByOwnerNameQuery request,
        CancellationToken token)
    {
        if (string.IsNullOrWhiteSpace(value: request.OwnerName)) return new List<PetProjectEntity>();

        HttpSender sender = new(hostUri: _configuration[key: "Routes:GitHubIntegrator:Url"]);

        var result = await sender.GetAsync<IEnumerable<PetProjectEntity>>(
            routePath: string.Format(
                format: _configuration[key: "Routes:GitHubIntegrator:InnerRoutes:GetPetProjectsListByOwnerName"],
                arg0: request.OwnerName),
            cancellationToken: token);

        return result ?? new List<PetProjectEntity>();
    }
}