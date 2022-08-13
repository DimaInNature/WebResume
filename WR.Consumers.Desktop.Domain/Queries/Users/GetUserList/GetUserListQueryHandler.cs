namespace WR.Consumers.Desktop.Domain.Queries.Users;

public sealed record class GetUserListQueryHandler
    : IRequestHandler<GetUserListQuery, IEnumerable<User>>
{
    private readonly IOptions<ApplicationSettingsModel> _configuration;

    public GetUserListQueryHandler(
        IOptions<ApplicationSettingsModel> configuration) =>
        _configuration = configuration;

    public async Task<IEnumerable<User>> Handle(
        GetUserListQuery request,
        CancellationToken token)
    {
        HttpSender sender = new(hostUri: _configuration.Value.Routes.GatewayRoute);

        var result = await sender.GetAsync<IEnumerable<User>>(
            routePath: _configuration.Value.Routes.Users.GetUsersListRoute,
            cancellationToken: token);

        return result ?? new List<User>();
    }
}