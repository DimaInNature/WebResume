namespace WR.Consumers.Web.Domain.Queries.PetProjects;

public sealed record class GetPetProjectListByOwnerNameQueryHandler
    : IRequestHandler<GetPetProjectListByOwnerNameQuery, IEnumerable<PetProject>>
{
    public async Task<IEnumerable<PetProject>> Handle(GetPetProjectListByOwnerNameQuery request, CancellationToken token)
    {
        if (string.IsNullOrWhiteSpace(value: request.OwnerName)) return new List<PetProject>();

        HttpSender sender = new(hostUri: "https://localhost:5021");

        var result = await sender.GetAsync<IEnumerable<PetProject>>(
            routePath: $"PetProjects/{request.OwnerName}",
            cancellationToken: token);

        return result ?? new List<PetProject>();
    }
}