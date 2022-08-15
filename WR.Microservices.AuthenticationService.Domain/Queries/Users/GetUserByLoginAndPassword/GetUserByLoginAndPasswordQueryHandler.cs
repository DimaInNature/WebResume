namespace WR.Microservices.AuthenticationService.Domain.Queries.Users;

public sealed record class GetUserByLoginAndPasswordQueryHandler
    : IRequestHandler<GetUserByLoginAndPasswordQuery, User?>
{
    private readonly IOptions<ApplicationSettingsModel> _configuration;

    public GetUserByLoginAndPasswordQueryHandler(
        IOptions<ApplicationSettingsModel> configuration) =>
        _configuration = configuration;

    public async Task<User?> Handle(
        GetUserByLoginAndPasswordQuery request,
        CancellationToken token)
    {
        if (string.IsNullOrWhiteSpace(value: request.Username) ||
            string.IsNullOrWhiteSpace(value: request.Password))
            return default;

        HttpSender sender = new(hostUri: _configuration.Value.Routes.Users.GetUserByLoginAndPasswordRoute.Host);

        var result = await sender.GetAsync<User>(
            routePath: _configuration.Value.Routes.Users.GetUserByLoginAndPasswordRoute.GetUserByLoginAndPassword(
                username: request.Username,
                password: request.Password),
            cancellationToken: token);

        return result;
    }
}