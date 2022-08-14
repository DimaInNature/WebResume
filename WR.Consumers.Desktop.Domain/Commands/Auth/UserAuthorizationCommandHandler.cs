namespace WR.Consumers.Desktop.Domain.Commands.Auth;

public sealed record class UserAuthorizationCommandHandler
    : IRequestHandler<UserAuthorizationCommand, string?>
{
    private readonly IOptions<ApplicationSettingsModel> _configuration;

    public UserAuthorizationCommandHandler(
        IOptions<ApplicationSettingsModel> configuration) =>
        _configuration = configuration;

    public async Task<string?> Handle(
        UserAuthorizationCommand request,
        CancellationToken token)
    {
        if (request.AuthRequest is null
            or { Username: "" }
            or { Password: "" })
            return default;

        HttpSender sender = new(hostUri: _configuration.Value.Routes.GatewayRoute);

        var result = await sender.PostAndReturnAsync<string, AuthorizationRequest>(
            routePath: _configuration.Value.Routes.AuthenticationRoute,
            serializableObj: request.AuthRequest,
            cancellationToken: token);

        return result;
    }
}