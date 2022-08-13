namespace WR.Consumers.Desktop.Domain.Commands.UserRoles;

public sealed record class DeleteUserRoleCommandHandler
    : IRequestHandler<DeleteUserRoleCommand>
{
    private readonly IOptions<ApplicationSettingsModel> _configuration;

    public DeleteUserRoleCommandHandler(
        IOptions<ApplicationSettingsModel> configuration) =>
        _configuration = configuration;

    public async Task<Unit> Handle(
        DeleteUserRoleCommand request,
        CancellationToken token)
    {
        if (Guid.Empty == request.Id) return default;

        HttpSender sender = new(hostUri: _configuration.Value.Routes.GatewayRoute);

        await sender.DeleteAsync(
            routePath: _configuration.Value.Routes.UserRoles.DeleteUserRole(id: request.Id),
            cancellationToken: token);

        return default;
    }
}