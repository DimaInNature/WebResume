namespace WR.Microservices.PetProjectService.Domain.Queries;

public sealed record class GetPetProjectByNameAndOwnerQueryHandler
    : IRequestHandler<GetPetProjectByNameAndOwnerNameQuery, PetProjectEntity?>
{
    private readonly IConfiguration _configuration;

    public GetPetProjectByNameAndOwnerQueryHandler(IConfiguration configuration) =>
         _configuration = configuration;

    public async Task<PetProjectEntity?> Handle(
        GetPetProjectByNameAndOwnerNameQuery request, CancellationToken token)
    {
        if (string.IsNullOrWhiteSpace(value: request.OwnerName) ||
            string.IsNullOrWhiteSpace(value: request.RepositoryName))
            return null;

        HttpSender sender = new(hostUri: _configuration[key: "Routes:GitHubIntegrator:Url"]);

        var result = await sender.GetAsync<PetProjectEntity>(
            routePath: string.Format(
                format: _configuration[key: "Routes:GitHubIntegrator:InnerRoutes:GetPetProjectByNameAndOwner"],
                arg0: request.OwnerName,
                arg1: request.RepositoryName),
            cancellationToken: token);

        return result;
    }
}