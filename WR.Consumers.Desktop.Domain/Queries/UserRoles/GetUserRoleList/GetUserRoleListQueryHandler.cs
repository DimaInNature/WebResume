namespace WR.Consumers.Desktop.Domain.Queries.UserRoles;

public sealed record class GetUserRoleListQueryHandler
    : IRequestHandler<GetUserRoleListQuery, IEnumerable<UserRole>>
{
    private readonly IOptions<ApplicationSettingsModel> _configuration;

    public GetUserRoleListQueryHandler(
        IOptions<ApplicationSettingsModel> configuration) =>
        _configuration = configuration;

    public async Task<IEnumerable<UserRole>> Handle(
        GetUserRoleListQuery request,
        CancellationToken token)
    {
        HttpSender sender = new(hostUri: _configuration.Value.Routes.GatewayRoute);

        var result = await sender.GetAsync<IEnumerable<UserRole>>(
            routePath: _configuration.Value.Routes.UserRoles.GetUserRolesListRoute,
            cancellationToken: token);

        return result ?? new List<UserRole>();
    }
}