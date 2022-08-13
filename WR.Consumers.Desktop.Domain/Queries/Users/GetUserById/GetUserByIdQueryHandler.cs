namespace WR.Consumers.Desktop.Domain.Queries.Users;

public sealed record class GetUserByIdQueryHandler
    : IRequestHandler<GetUserByIdQuery, User?>
{
    private readonly IOptions<ApplicationSettingsModel> _configuration;

    public GetUserByIdQueryHandler(
        IOptions<ApplicationSettingsModel> configuration) =>
        _configuration = configuration;

    public async Task<User?> Handle(
        GetUserByIdQuery request,
        CancellationToken token)
    {
        if (Guid.Empty == request.Id) return default;

        HttpSender sender = new(hostUri: _configuration.Value.Routes.GatewayRoute);

        var result = await sender.GetAsync<User>(
            routePath: _configuration.Value.Routes.Users.GetUserById(id: request.Id),
            cancellationToken: token);

        return result;
    }
}