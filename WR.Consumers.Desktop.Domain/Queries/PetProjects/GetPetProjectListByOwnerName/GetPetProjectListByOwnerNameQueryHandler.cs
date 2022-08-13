namespace WR.Consumers.Desktop.Domain.Queries.PetProjects;

public sealed record class GetPetProjectListByOwnerNameQueryHandler
    : IRequestHandler<GetPetProjectListByOwnerNameQuery, IEnumerable<PetProject>>
{
    private readonly IOptions<ApplicationSettingsModel> _configuration;

    public GetPetProjectListByOwnerNameQueryHandler(
        IOptions<ApplicationSettingsModel> configuration) =>
        _configuration = configuration;

    public async Task<IEnumerable<PetProject>> Handle(
        GetPetProjectListByOwnerNameQuery request,
        CancellationToken token)
    {
        if (string.IsNullOrWhiteSpace(value: request.OwnerName)) return new List<PetProject>();

        HttpSender sender = new(hostUri: _configuration.Value.Routes.GatewayRoute);

        var result = await sender.GetAsync<IEnumerable<PetProject>>(
            routePath: _configuration.Value.Routes.PetProjects.GetPetProjectListByOwnerName(ownerName: "DimaInNature"),
            cancellationToken: token);

        return result ?? new List<PetProject>();
    }
}