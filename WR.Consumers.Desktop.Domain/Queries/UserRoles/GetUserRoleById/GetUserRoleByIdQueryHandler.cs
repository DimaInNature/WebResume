namespace WR.Consumers.Desktop.Domain.Queries.UserRoles;

public sealed record class GetUserRoleByIdQueryHandler
    : IRequestHandler<GetUserRoleByIdQuery, UserRole?>
{
    private readonly IOptions<ApplicationSettingsModel> _configuration;

    public GetUserRoleByIdQueryHandler(
        IOptions<ApplicationSettingsModel> configuration) =>
        _configuration = configuration;

    public async Task<UserRole?> Handle(
        GetUserRoleByIdQuery request,
        CancellationToken token)
    {
        if (Guid.Empty == request.Id) return default;

        HttpSender sender = new(hostUri: _configuration.Value.Routes.GatewayRoute);

        var result = await sender.GetAsync<UserRole>(
            routePath: _configuration.Value.Routes.UserRoles.GetUserRoleById(id: request.Id),
            cancellationToken: token);

        return result;
    }
}