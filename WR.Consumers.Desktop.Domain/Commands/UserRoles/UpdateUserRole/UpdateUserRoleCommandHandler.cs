namespace WR.Consumers.Desktop.Domain.Commands.UserRoles;

public sealed record class UpdateUserRoleCommandHandler
    : IRequestHandler<UpdateUserRoleCommand>
{
    private readonly IConfiguration _configuration;

    public UpdateUserRoleCommandHandler(
        IConfiguration configuration) =>
        _configuration = configuration;

    public async Task<Unit> Handle(
        UpdateUserRoleCommand request,
        CancellationToken token)
    {
        if (request.UserRole is null
            or { Name: "" })
            return default;

        HttpSender sender = new(hostUri: _configuration[key: "Routes:Gateway"]);

        await sender.PutAsync(
            routePath: _configuration[key: "Routes:UserRoles:UpdateUserRole"],
            serializableObj: request.UserRole,
            cancellationToken: token);

        return default;
    }
}