namespace WR.Consumers.Desktop.Domain.Commands.UserRoles;

public sealed record class UpdateUserRoleCommandHandler
    : IRequestHandler<UpdateUserRoleCommand>
{
    private readonly IOptions<ApplicationSettingsModel> _configuration;

    public UpdateUserRoleCommandHandler(
        IOptions<ApplicationSettingsModel> configuration) =>
        _configuration = configuration;

    public async Task<Unit> Handle(
        UpdateUserRoleCommand request,
        CancellationToken token)
    {
        if (request.UserRole is null
            or { Name: "" })
            return default;

        HttpSender sender = new(hostUri: _configuration.Value.Routes.GatewayRoute);

        await sender.PutAsync(
            routePath: _configuration.Value.Routes.UserRoles.UpdateUserRoleRoute,
            serializableObj: request.UserRole,
            cancellationToken: token);

        return default;
    }
}