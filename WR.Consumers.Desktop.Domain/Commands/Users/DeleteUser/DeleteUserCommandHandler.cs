namespace WR.Consumers.Desktop.Domain.Commands.Users;

public sealed record class DeleteUserCommandHandler
    : IRequestHandler<DeleteUserCommand>
{
    private readonly IOptions<ApplicationSettingsModel> _configuration;

    public DeleteUserCommandHandler(
        IOptions<ApplicationSettingsModel> configuration) =>
        _configuration = configuration;

    public async Task<Unit> Handle(
        DeleteUserCommand request,
        CancellationToken token)
    {
        if (Guid.Empty == request.Id) return default;

        HttpSender sender = new(hostUri: _configuration.Value.Routes.GatewayRoute);

        await sender.DeleteAsync(
            routePath: _configuration.Value.Routes.Users.DeleteUser(id: request.Id),
            cancellationToken: token);

        return default;
    }
}