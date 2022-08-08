namespace WR.Consumers.Desktop.Domain.Queries.UserRoles;

public sealed record class GetUserRoleByIdQueryHandler
    : IRequestHandler<GetUserRoleByIdQuery, UserRole?>
{
    private readonly IConfiguration _configuration;

    public GetUserRoleByIdQueryHandler(
        IConfiguration configuration) =>
        _configuration = configuration;

    public async Task<UserRole?> Handle(
        GetUserRoleByIdQuery request,
        CancellationToken token)
    {
        if (Guid.Empty == request.Id) return default;

        HttpSender sender = new(hostUri: _configuration[key: "Routes:Gateway"]);

        var result = await sender.GetAsync<UserRole>(
            routePath: string.Format(
                format: _configuration[key: "Routes:UserRoles:GetUserRoleById"],
                arg0: request.Id),
            cancellationToken: token);

        return result;
    }
}