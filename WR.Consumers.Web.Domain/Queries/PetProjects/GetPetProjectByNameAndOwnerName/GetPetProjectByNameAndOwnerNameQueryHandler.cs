namespace WR.Consumers.Web.Domain.Queries.PetProjects;

public sealed record class GetPetProjectByNameAndOwnerNameQueryHandler
    : IRequestHandler<GetPetProjectByNameAndOwnerNameQuery, PetProject?>
{
    public async Task<PetProject?> Handle(
        GetPetProjectByNameAndOwnerNameQuery request,
        CancellationToken token)
    {
        if (string.IsNullOrWhiteSpace(value: request.OwnerName) ||
            string.IsNullOrWhiteSpace(value: request.Name))
            return null;

        HttpSender sender = new(hostUri: "https://localhost:5021");

        var result = await sender.GetAsync<PetProject>(
            routePath: $"PetProjects/{request.OwnerName}",
            cancellationToken: token);

        return result;
    }
}