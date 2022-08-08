namespace WR.Consumers.Desktop.Domain.Queries.PetProjects;

public sealed record class GetPetProjectListByOwnerNameQueryHandler
    : IRequestHandler<GetPetProjectListByOwnerNameQuery, IEnumerable<PetProject>>
{
    private readonly IConfiguration _configuration;

    public GetPetProjectListByOwnerNameQueryHandler(
        IConfiguration configuration) =>
        _configuration = configuration;

    public async Task<IEnumerable<PetProject>> Handle(
        GetPetProjectListByOwnerNameQuery request,
        CancellationToken token)
    {
        if (string.IsNullOrWhiteSpace(value: request.OwnerName)) return new List<PetProject>();

        HttpSender sender = new(hostUri: _configuration[key: "Routes:Gateway"]);

        var result = await sender.GetAsync<IEnumerable<PetProject>>(
            routePath: string.Format(
                format: _configuration[key: "Routes:PetProjects:GetPetProjectListByOwnerName"],
                arg0: _configuration[key: "User:Nickname"]),
            cancellationToken: token);

        return result ?? new List<PetProject>();
    }
}