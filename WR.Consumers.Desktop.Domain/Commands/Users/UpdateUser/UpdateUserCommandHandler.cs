namespace WR.Consumers.Desktop.Domain.Commands.Users;

public sealed record class UpdateUserCommandHandler
    : IRequestHandler<UpdateUserCommand>
{
    private readonly IOptions<ApplicationSettingsModel> _configuration;

    public UpdateUserCommandHandler(
        IOptions<ApplicationSettingsModel> configuration) =>
        _configuration = configuration;

    public async Task<Unit> Handle(
        UpdateUserCommand request,
        CancellationToken token)
    {
        if (request.User is null
            or { Username: "" }
            or { Password: "" })
            return default;

        HttpSender sender = new(hostUri: _configuration.Value.Routes.GatewayRoute);

        await sender.PutAsync(
            routePath: _configuration.Value.Routes.Users.UpdateUserRoute,
            serializableObj: request.User,
            cancellationToken: token);

        return default;
    }
}