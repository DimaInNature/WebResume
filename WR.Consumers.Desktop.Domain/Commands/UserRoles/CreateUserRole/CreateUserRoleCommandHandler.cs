namespace WR.Consumers.Desktop.Domain.Commands.UserRoles;

public sealed record class CreateUserRoleCommandHandler
    : IRequestHandler<CreateUserRoleCommand>
{
    private readonly IOptions<ApplicationSettingsModel> _configuration;

    public CreateUserRoleCommandHandler(
        IOptions<ApplicationSettingsModel> configuration) =>
        _configuration = configuration;

    public async Task<Unit> Handle(
        CreateUserRoleCommand request,
        CancellationToken token)
    {
        if (request.UserRole is null
            or { Name: "" })
            return default;

        HttpSender sender = new(hostUri: _configuration.Value.Routes.GatewayRoute);

        await sender.PostAsync(
            routePath: _configuration.Value.Routes.UserRoles.CreateUserRoleRoute,
            serializableObj: request.UserRole,
            cancellationToken: token);

        return default;
    }
}