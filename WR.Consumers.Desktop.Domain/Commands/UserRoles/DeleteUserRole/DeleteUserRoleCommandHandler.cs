namespace WR.Consumers.Desktop.Domain.Commands.UserRoles;

public sealed record class DeleteUserRoleCommandHandler
    : IRequestHandler<DeleteUserRoleCommand>
{
    private readonly IConfiguration _configuration;

    public DeleteUserRoleCommandHandler(
        IConfiguration configuration) =>
        _configuration = configuration;

    public async Task<Unit> Handle(
        DeleteUserRoleCommand request,
        CancellationToken token)
    {
        if (Guid.Empty == request.Id) return default;

        HttpSender sender = new(hostUri: _configuration[key: "Routes:Gateway"]);

        await sender.DeleteAsync(
            routePath: string.Format(
                format: _configuration[key: "Routes:UserRoles:DeleteUserRole"],
                arg0: request.Id),
            cancellationToken: token);

        return default;
    }
}