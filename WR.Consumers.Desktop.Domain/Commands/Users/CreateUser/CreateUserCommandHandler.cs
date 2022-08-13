namespace WR.Consumers.Desktop.Domain.Commands.Users;

public sealed record class CreateUserCommandHandler
    : IRequestHandler<CreateUserCommand, User?>
{
    private readonly IOptions<ApplicationSettingsModel> _configuration;

    public CreateUserCommandHandler(
        IOptions<ApplicationSettingsModel> configuration) =>
        _configuration = configuration;

    public async Task<User?> Handle(
        CreateUserCommand request,
        CancellationToken token)
    {
        if (request.User is null
            or { Username: "" }
            or { Password: "" })
            return default;

        HttpSender sender = new(hostUri: _configuration.Value.Routes.GatewayRoute);

        var response = await sender.PostAndReturnAsync(
            routePath: _configuration.Value.Routes.Users.CreateUserRoute,
            serializableObj: request.User,
            cancellationToken: token);

        return response;
    }
}