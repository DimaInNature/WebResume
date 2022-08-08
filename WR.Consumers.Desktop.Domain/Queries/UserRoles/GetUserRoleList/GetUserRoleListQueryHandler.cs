namespace WR.Consumers.Desktop.Domain.Queries.UserRoles;

public sealed record class GetUserRoleListQueryHandler
    : IRequestHandler<GetUserRoleListQuery, IEnumerable<UserRole>>
{
    private readonly IConfiguration _configuration;

    public GetUserRoleListQueryHandler(
        IConfiguration configuration) =>
        _configuration = configuration;

    public async Task<IEnumerable<UserRole>> Handle(
        GetUserRoleListQuery request,
        CancellationToken token)
    {
        HttpSender sender = new(hostUri: _configuration[key: "Routes:Gateway"]);

        var result = await sender.GetAsync<IEnumerable<UserRole>>(
            routePath: _configuration[key: "Routes:UserRoles:GetUserRolesList"],
            cancellationToken: token);

        return result ?? new List<UserRole>();
    }
}