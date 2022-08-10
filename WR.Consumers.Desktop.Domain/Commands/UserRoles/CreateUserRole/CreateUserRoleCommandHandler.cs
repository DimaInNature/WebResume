namespace WR.Consumers.Desktop.Domain.Commands.UserRoles;

public sealed record class CreateUserRoleCommandHandler
    : IRequestHandler<CreateUserRoleCommand>
{
    private readonly IConfiguration _configuration;

    public CreateUserRoleCommandHandler(
        IConfiguration configuration) =>
        _configuration = configuration;

    public async Task<Unit> Handle(
        CreateUserRoleCommand request,
        CancellationToken token)
    {
        if (request.UserRole is null
            or { Name: "" })
            return default;

        HttpSender sender = new(hostUri: _configuration[key: "Routes:Gateway"]);

        await sender.PostAsync(
            routePath: _configuration[key: "Routes:UserRoles:CreateUserRole"],
            serializableObj: request.UserRole,
            cancellationToken: token);

        return default;
    }
}